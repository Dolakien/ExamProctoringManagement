using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class UpdateFormSwapDto
    {
        public string FormId { get; set; }

        public bool? Type { get; set; }

        public bool? IsAllowed { get; set; }

        public bool? Status { get; set; }
    }
}
