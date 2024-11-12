using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class SlotRoomSubjectDTO
    {
        public string SlotRoomSubjectId { get; set; }

        public string SlotReferenceId { get; set; }

        public string SubjectId { get; set; }

        public bool? Status { get; set; }

    }
}
