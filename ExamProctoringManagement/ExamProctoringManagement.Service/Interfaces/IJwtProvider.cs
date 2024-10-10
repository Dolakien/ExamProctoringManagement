using AutoMapper.Execution;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
    }
}
