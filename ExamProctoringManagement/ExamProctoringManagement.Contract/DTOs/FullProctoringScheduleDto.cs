using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class FullProctoringScheduleDto
    {
        public string ScheduleId { get; set; }

        public string SemesterName { get; set; }

        public string ExamName { get; set; }  

        public string UserId { get; set; }

        public string ProctorType { get; set; }

        public bool? Status { get; set; }

        public bool? IsFinished { get; set; }

        public string SlotId { get; set; }

        public DateTime? Date { get; set; }

        public TimeOnly? Start { get; set; }

        public TimeOnly? End { get; set; }

        public string RoomName { get; set; }

        public List<SubjectDto> Subjects { get; set; }

        public string GroupId { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
