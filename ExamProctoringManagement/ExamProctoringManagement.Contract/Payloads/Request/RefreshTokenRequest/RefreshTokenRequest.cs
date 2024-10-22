using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest
{
    public class RefreshTokenRequest
    {
        public string UserId { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
