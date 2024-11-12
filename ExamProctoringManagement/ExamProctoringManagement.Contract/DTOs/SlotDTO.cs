using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class SlotDTO
    {
        public string SlotId { get; set; }

        public DateTime? Date { get; set; }

        public TimeOnly? Start { get; set; }

        public TimeOnly? End { get; set; }

        public bool? Status { get; set; }

        public string ExamId { get; set; }
    }
}
