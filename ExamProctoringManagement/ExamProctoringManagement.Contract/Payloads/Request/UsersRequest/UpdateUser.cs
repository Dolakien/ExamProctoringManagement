using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Request.UsersRequest
{
    public class UpdateUser
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public int roleID {  get; set; }
        public bool status {  get; set; }
        public DateTime? Dob { get; set; }
    }
}
