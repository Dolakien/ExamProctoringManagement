using AutoMapper.Execution;
using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<PagedList<UserDto>> GetUsers(GetUsersQuery getUsersQuery);
        public Task<User> GetUserById(string Id);
        public Task<User> CheckLogin(LoginRequest loginRequest);
        public Task<bool> UpdatePassword(PasswordRequest passwordRequest);
        Task<User> CreateUser(CreateUserRequest createUserRequest);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllAsync();

    }
}
