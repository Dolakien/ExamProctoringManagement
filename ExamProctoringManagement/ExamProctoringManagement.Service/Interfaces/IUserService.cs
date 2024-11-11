using AutoMapper.Execution;
using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using ExamProctoringManagement.Contract.Payloads.Response;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;


namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IUserService
    {
        Task<PagedList<UserDto>> GetAllUsers(GetUsersQuery getUsersQuery);
        Task<LoginResponse> CreateUser(CreateUserRequest createUserRequest);
        Task<LoginResponse> Login(Contract.Payloads.Request.UsersRequest.LoginRequest loginRequest);
        Task<bool> UpdatePassword(PasswordRequest passwordRequest);
        Task<User> GetUserById(string Id);
        Task<User> GetUserByEmail(string email);
        Task<bool> ResetPassword(ResetPasswordRequest resetPasswordRequest);
        Task<bool> SendResetPasswordEmail(string email, string resetLink);
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> UpdateUserAsync(UpdateUser user);
        Task DeleteUserAsync(string id);
    }
}
