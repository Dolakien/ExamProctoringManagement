using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.DAO
{
    public class RefreshTokenDAO
    {
        private readonly ExamProctoringManagementDBContext _context
            ;
        public RefreshTokenDAO(ExamProctoringManagementDBContext examProctoringManagementContext)
        {
            _context = examProctoringManagementContext;
        }

        public void Add(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);
        }

        public async Task<RefreshToken> GetRefreshToken(string userId)
        {
            // Lấy refresh token ra
            return await _context.RefreshTokens
                .Include(rf => rf.User)
                .ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(rf => rf.UserId == userId);
        }
        public void Delete(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
        }

        public void Update(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
        }

    }
}
