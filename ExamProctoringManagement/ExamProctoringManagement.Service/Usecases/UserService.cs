using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Service.Authentication;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProctoringManagement.Repository.Repositories;

namespace ExamProctoringManagement.Service.Usecases
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly SmtpSettings _smtpSetting;


        public UserService(IUserRepository userRepository,
            IJwtProvider jwtProvider,
            IRefreshTokenRepository refreshTokenRepository,
            IOptions<SmtpSettings> smtpSetting)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _smtpSetting = smtpSetting.Value;
        }
        public async Task<LoginResponse> CreateUser(CreateUserRequest createUserRequest)
        {
            var user = await _userRepository.CreateUser(createUserRequest);
            bool result = false;
            // get refresh token
            var refreshToken = await _refreshTokenRepository.GetRefreshTokenByUserID(user.UserId);
            // get member 
            // Gen token & refresh token
            var jwtToken = _jwtProvider.GenerateToken(user);
            var refreshTokenString = _jwtProvider.GenerateRefreshToken();

            // check refresh token if null => create 
            if (refreshToken == null)
            {
                var newRefreshToken = new RefreshToken
                {
                    UserId = user.UserId,
                    Token = refreshTokenString,
                    ExpiryDate = DateTime.UtcNow.AddHours(12)
                };
                result = await _refreshTokenRepository.AddRefreshToken(newRefreshToken);
                if (!result)
                {
                    return default;
                }
            }
            // Update token
            else
            {
                refreshToken.Token = refreshTokenString;
                refreshToken.ExpiryDate = DateTime.UtcNow.AddHours(12);
                result = await _refreshTokenRepository.UpdateRefreshToken(refreshToken);
                if (!result)
                {
                    return default;
                }
            }
            var loginResponse = new LoginResponse
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                JwtToken = jwtToken,
                RoleName = user.Role.RoleName,
                RefreshToken = refreshTokenString
            };

            await SendWelcomeEmail(user.UserName, user.Email, createUserRequest.Password);

            return loginResponse;
        }

        public async Task<PagedList<UserDto>> GetAllUsers(GetUsersQuery getUsersQuery)
        {
            return await _userRepository.GetUsers(getUsersQuery);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<User> GetUserById(string Id)
        {
            return await _userRepository.GetUserById(Id);
        }

        public async Task<LoginResponse> Login(Contract.Payloads.Request.UsersRequest.LoginRequest loginRequest)
        {
            var user = await _userRepository.CheckLogin(loginRequest);
            bool result = false;
            // get refresh token
            var refreshToken = await _refreshTokenRepository.GetRefreshTokenByUserID(user.UserId);
            // Gen token & refresh token
            var jwtToken = _jwtProvider.GenerateToken(user);
            var refreshTokenString = _jwtProvider.GenerateRefreshToken();

            // check refresh token if null => create 
            if (refreshToken == null)
            {
                var newRefreshToken = new RefreshToken
                {
                    UserId = user.UserId,
                    Token = refreshTokenString,
                    ExpiryDate = DateTime.UtcNow.AddHours(12)
                };
                result = await _refreshTokenRepository.AddRefreshToken(newRefreshToken);
                if (!result)
                {
                    return default;
                }
            }
            // Update token
            else
            {
                refreshToken.Token = refreshTokenString;
                refreshToken.ExpiryDate = DateTime.UtcNow.AddHours(12);
                result = await _refreshTokenRepository.UpdateRefreshToken(refreshToken);
                if (!result)
                {
                    return default;
                }
            }
            var loginResponse = new LoginResponse
            {
                UserId = user.UserId,
                UserName = user.UserName,
                JwtToken = jwtToken,
                RoleName = user.Role.RoleName,
                RefreshToken = refreshTokenString
            };
            return loginResponse;
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var user = await _userRepository.GetUserByEmail(resetPasswordRequest.Email);

            if (user == null)
            {
                return false;
            }

            var passwordRequest = new PasswordRequest
            {
                Email = resetPasswordRequest.Email,
                OldPassword = resetPasswordRequest.NewPassword,
                NewPassword = resetPasswordRequest.NewPassword
            };
            var isUpdate = await _userRepository.UpdatePassword(passwordRequest);

            await SendPasswordChangedEmail(user.Email);

            return isUpdate;
        }

        public async Task<bool> SendResetPasswordEmail(string email, string resetLink)
        {
            {
                var user = await _userRepository.GetUserByEmail(email);
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Exam Proctoring Management System", _smtpSetting.Username));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "Reset Your Password";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
                <p>Dear {user.UserName},</p>
                <p>You have requested to reset your password. Please click the link below to reset your password:</p>
                <p><a href='{resetLink}'>Reset Password</a></p>
                <p>If you did not request this, please ignore this email.</p>
                <p>Thank you,</p>
            ";

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    try
                    {
                        client.Connect(_smtpSetting.SmtpServer, _smtpSetting.Port, _smtpSetting.UseSsl);
                        client.Authenticate(_smtpSetting.Username, _smtpSetting.Password);
                        await client.SendAsync(message);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email: {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        await client.DisconnectAsync(true);
                    }
                }
            }
        }

        public async Task<bool> UpdatePassword(PasswordRequest passwordRequest)
        {
            var isUpdate = await _userRepository.UpdatePassword(passwordRequest);

            await SendPasswordUpdateEmail(passwordRequest.Email);

            return isUpdate;
        }

        private async Task SendPasswordUpdateEmail(string Email)
        {
            var user = await _userRepository.GetUserByEmail(Email);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Exam Proctoring Management System", _smtpSetting.Username));
            message.To.Add(new MailboxAddress("", user.Email));
            message.Subject = "Password Changed";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
            <p>Dear {user.UserName},</p>
            <p>Your password has been successfully changed.</p>
            <p>If you did not make this change, please contact us immediately.</p>
            <p>Best regards,</p>
            <p>Exam Proctoring Management System</p>
        ";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_smtpSetting.SmtpServer, _smtpSetting.Port, _smtpSetting.UseSsl);
                    await client.AuthenticateAsync(_smtpSetting.Username, _smtpSetting.Password);
                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }

        private async Task SendWelcomeEmail(string name, string email, string password)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Exam Proctoring Management System", _smtpSetting.Username));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Password Changed";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
                <p>Dear {name},</p>
                <p>Welcome to Exam Proctoring Management System! We are thrilled to have you on board.</p>
                <p>Enjoy exploring our platform and discovering great opportunities!</p>
                <p>Your Password: {password}</p>
                <p>Best regards,</p>
                <p>Exam Proctoring Management System</p>
            ";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpSetting.SmtpServer, _smtpSetting.Port, _smtpSetting.UseSsl);
                    client.Authenticate(_smtpSetting.Username, _smtpSetting.Password);
                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }

        private async Task SendPasswordChangedEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Exam Proctoring Management System", _smtpSetting.Username));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Password Changed";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
                <p>Dear {user.UserName},</p>
                <p>Your password has been successfully changed.</p>
                <p>If you did not make this change, please contact support immediately.</p>
                <p>Thank you,</p>
            ";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpSetting.SmtpServer, _smtpSetting.Port, _smtpSetting.UseSsl);
                    client.Authenticate(_smtpSetting.Username, _smtpSetting.Password);
                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> UpdateUserAsync(UpdateUser user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
