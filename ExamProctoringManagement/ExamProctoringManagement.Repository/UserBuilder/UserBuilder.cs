using AutoMapper.Execution;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Role = ExamProctoringManagement.Contract.Enum.Role;


using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.UserBuilder;

    public class UserBuilder
    {
        private string _userId;
        private int? _roleId;
        private string _userName;
        private byte[] _passwordHash;
        private byte[] _passwordSalt;
        private string _fullName;
        private string _mainMajor;
        private string _address;
        private bool? _gender;
        private string _email;
        private string _phone;
        private bool? _status;
        private DateTime? _dob;

        private UserBuilder()
        {
        }

        public static UserBuilder Empty() => new();

        public UserBuilder UserId(string userId)
        {
            _userId = userId;
            return this;
        }
        public UserBuilder RoleId(int roleId)
        {
        _roleId = Role.FromValue(roleId).Value;
        return this;
    }

        public UserBuilder UserName(string userName)
        {
            _userName = userName;
            return this;
        }

        public UserBuilder PassWord(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                _passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                _passwordSalt = hmac.Key;
            };
            return this;
        }

        public UserBuilder FullName(string fullName)
        {
            _fullName = fullName;
            return this;
        }

        public UserBuilder MainMajor(string mainMajor)
        {
            _mainMajor = mainMajor;
            return this;
        }

        public UserBuilder Address(string address)
        {
            _address = address;
            return this;
        }

        public UserBuilder Gender(bool gender)
        {
            _gender = gender;
            return this;
        }

        public UserBuilder Email(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder Phone(string phone)
        {
            _phone = phone;
            return this;
        }

        public UserBuilder Status(bool status)
        {
            _status = status;
            return this;
        }
        public UserBuilder Dob(DateTime? dob)
        {
            _dob = dob;
            return this;
        }

        public User Create()
        {
            return new User()
            {
                UserId = _userId,
                RoleId = _roleId ?? Role.Lecturer.Value,
                PhoneNumber = _phone,
                PasswordHash = _passwordHash,
                PasswordSalt = _passwordSalt,
                Address = _address,
                Status = _status,
                UserName = _userName,
                FullName = _fullName,
                MainMajor = _mainMajor,
                Gender = _gender,
                Email = _email,
                DoB = _dob
            };
        }
    }

