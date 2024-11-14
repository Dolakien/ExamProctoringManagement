using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class RegistrationFormUserDTO
    {
        public string FormId { get; set; }

        public string UserId { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
        public string ScheduleID { get; set; }
        public string ProctoringType { get; set; }
        public DateTime? Date { get; set; }
        public TimeOnly? StartDate { get; set; }
        public TimeOnly? EndDate { get; set; }
    }
}
