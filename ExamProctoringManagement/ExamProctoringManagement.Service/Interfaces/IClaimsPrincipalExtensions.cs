using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IClaimsPrincipalExtensions
    {
        ClaimsPrincipal GetTokenPrincipal(string token);
    }
}
