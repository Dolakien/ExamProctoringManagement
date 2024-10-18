using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Request.UsersRequest
{
    public class PasswordRequest
    {
        public string Email { get; set; }
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
    }
}
