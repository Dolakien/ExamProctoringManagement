using AutoMapper.Execution;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            // create claims
            var claims = new Claim[]
            {
            new(ClaimTypes.NameIdentifier, user.UserId),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.RoleName) // Chuyển đổi RoleId sang string
            };
            // create sign credentials
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey))
                , SecurityAlgorithms.HmacSha512Signature);

            var token = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_options.ExpiryTimeFrame),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(token);
            var tokenResult = tokenHandler.WriteToken(securityToken);

            return tokenResult;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }
    }
}
