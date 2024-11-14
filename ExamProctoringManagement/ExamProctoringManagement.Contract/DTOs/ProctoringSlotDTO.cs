using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class ProctoringSlotDTO
    {
        public string UserID { get; set; }
        public string ProctorType { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly StartDate { get; set; }
        public TimeOnly EndDate { get; set; }

        public int count {  get; set; }
    }
}
