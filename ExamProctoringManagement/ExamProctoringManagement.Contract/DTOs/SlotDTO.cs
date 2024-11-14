using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class SlotDTO
    {
        public DateTime? Date { get; set; }
        public string Start { get; set; } // Sử dụng định dạng "HH:mm"
        public string End { get; set; }   // Sử dụng định dạng "HH:mm"
        public string ExamId { get; set; }
    }

}
