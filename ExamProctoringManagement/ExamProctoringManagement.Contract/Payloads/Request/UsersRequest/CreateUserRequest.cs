using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Request.UsersRequest
{
    public class CreateUserRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string MainMajor {  get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public DateTime? Dob { get; set; }
    }
}
