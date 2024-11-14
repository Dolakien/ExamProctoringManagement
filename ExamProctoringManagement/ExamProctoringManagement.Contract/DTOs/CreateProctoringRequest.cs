using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class CreateProctoringRequest
    {
        public string ProctorType { get; set; }

        public string SlotReferenceId { get; set; }

        public int Count { get; set; }
    }
}
