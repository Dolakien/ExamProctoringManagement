using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class RefreshTokenIsExpiredException : BadRequestException
    {
        public RefreshTokenIsExpiredException() : base("Refresh Token were Expired")
        {
        }
    }
}
