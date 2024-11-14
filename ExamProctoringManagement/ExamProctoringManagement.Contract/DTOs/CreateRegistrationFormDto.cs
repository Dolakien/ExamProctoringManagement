using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class CreateRegistrationFormDto
    {
        public string FormId { get; set; }

        public string UserId { get; set; }

        public string ProctoringID { get; set; }
    }
}
