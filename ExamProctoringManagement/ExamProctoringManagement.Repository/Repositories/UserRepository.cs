using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Repository.UserBuilder;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProctoringManagement.Repository.Exceptions;
using AutoMapper.Execution;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserRepository(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<User> CheckLogin(LoginRequest loginRequest)
        {
            var result = await _uow.UserDAO.GetUserByEmailLogin(loginRequest.Email, m => m.Role);
            if (result == null)
            {
                throw new UserNotFoundException(loginRequest.Email);
            }

            // check password
            using var hmac = new HMACSHA512(result.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != result.PasswordHash[i]) throw new PasswordInvalidException();
            }

            return result;
        }

        public async Task<User> CreateUser(CreateUserRequest createUserRequest)
        {
            var existUser = await _uow.UserDAO.GetUserByIDCreate(createUserRequest.UserId);
            if (existUser != null)
            {
                throw new ExistUserException(createUserRequest.UserId);
            }

            // use member builder to create a member object
            User user = UserBuilder
                .UserBuilder.Empty()
                .PassWord(createUserRequest.Password)
                .UserName(createUserRequest.UserName)
                .UserId(createUserRequest.UserId)
                .FullName(createUserRequest.FullName)
                .Address(createUserRequest.Address)
                .Phone(createUserRequest.Phone)
                .Email(createUserRequest.Email)
                .MainMajor(createUserRequest.MainMajor)
                .Gender(createUserRequest.Gender)
                .Dob(createUserRequest.Dob)
                .Create();
            _uow.UserDAO.Add(user);
            await _uow.SaveChangesAsync();
            var returnUser = await _uow.UserDAO.GetUserByIDCreate(createUserRequest.UserId, m=>m.Role);
            return returnUser;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _uow.UserDAO.GetAllAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _uow.UserDAO.GetUserByEmail(email);
        }

        public async Task<User> GetUserById(string Id)
        {
            var result = await _uow.UserDAO.GetUserByIDCreate(Id);
            if (result == null)
            {
                return default;
            }

            return result;
        }

        public async Task<PagedList<UserDto>> GetUsers(GetUsersQuery getUsersQuery)
        {
            var query = _uow.UserDAO.GetAllUser(getUsersQuery.SearchTerm, getUsersQuery.SortColumn,
                getUsersQuery.SortOrder);
            var result = await PagedList<UserDto>.CreateAsync(query.ProjectTo<UserDto>(_mapper.ConfigurationProvider),
                getUsersQuery.PageNumber, getUsersQuery.PageSize);
            return result;
        }

        public async Task<bool> UpdatePassword(PasswordRequest passwordRequest)
        {
            var user = await _uow.UserDAO.GetUserByEmail(passwordRequest.Email);
            // check old password
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordRequest.OldPassword));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i]) throw new OldPasswordInvalidException();
            }
            // update new password
            using (var hash = new HMACSHA512())
            {
                user.PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(passwordRequest.NewPassword));
                user.PasswordSalt = hash.Key;
            }
            _uow.UserDAO.Update(user);
            return await _uow.SaveChangesAsync();
        }

    }
}
