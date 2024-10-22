using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string MainMajor { get; set; }


        /*    public string Status { get; set; }*/

        public DateTime? Dob { get; set; }
    }
}
