using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class ExamDTO
    {
        public string ExamId { get; set; }

        public string ExamName { get; set; }

        public string Type { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string SemesterId { get; set; }

        public bool? Status { get; set; }
    }
}
