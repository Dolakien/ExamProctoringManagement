using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IUnitOfWork _uow;

        public RefreshTokenRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<RefreshToken> GetRefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var refreshToken = await _uow.RefreshTokenDAO.GetRefreshToken(refreshTokenRequest.UserId);
            if (refreshToken == null)
            {
                throw new RefreshTokenNotFoundException(refreshTokenRequest.UserId);
            }
            // check refresh token có trùng với request refresh token không?
            if (refreshTokenRequest.RefreshToken != refreshToken.Token)
            {
                throw new RefreshTokenDoesNotMatch();
            }
            // Refresh Token hết hạn => login lại để cấp refresh token mới
            if (refreshToken.ExpiryDate < DateTime.UtcNow)
            {
                throw new RefreshTokenIsExpiredException();
            }

            return refreshToken;
        }

        public async Task<RefreshToken> GetRefreshTokenByUserID(string userId)
        {
            var refreshToken = await _uow.RefreshTokenDAO.GetRefreshToken(userId);
            return (refreshToken != null) ? refreshToken : default;
        }

        public async Task<bool> AddRefreshToken(RefreshToken refreshToken)
        {
            _uow.RefreshTokenDAO.Add(refreshToken);
            return await _uow.SaveChangesAsync();
        }

        public async Task<bool> UpdateRefreshToken(RefreshToken refreshToken)
        {
            _uow.RefreshTokenDAO.Update(refreshToken);
            return await _uow.SaveChangesAsync();
        }
    }
}
