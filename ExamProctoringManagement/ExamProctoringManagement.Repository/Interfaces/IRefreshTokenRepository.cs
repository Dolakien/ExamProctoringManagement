using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetRefreshToken(RefreshTokenRequest refreshTokenRequest);
        Task<RefreshToken> GetRefreshTokenByUserID(string userId);
        Task<bool> AddRefreshToken(RefreshToken refreshToken);
        Task<bool> UpdateRefreshToken(RefreshToken refreshToken);
    }
}
