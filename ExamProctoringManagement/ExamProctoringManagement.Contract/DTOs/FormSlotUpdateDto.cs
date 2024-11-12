using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class FormSlotUpdateDto
    {
        public string FormSlotId { get; set; }

        public bool? Status { get; set; }
    }
}
