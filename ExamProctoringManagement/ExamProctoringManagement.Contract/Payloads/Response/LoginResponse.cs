using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Response
{
    public class LoginResponse
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }

        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
