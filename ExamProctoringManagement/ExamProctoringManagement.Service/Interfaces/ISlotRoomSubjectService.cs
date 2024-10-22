using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface ISlotRoomSubjectService
    {
        Task<SlotRoomSubject> GetSlotRoomSubjectByIdAsync(string id);
        Task<IEnumerable<SlotRoomSubject>> GetAllSlotRoomSubjectsAsync();
        Task<SlotRoomSubject> CreateSlotRoomSubjectAsync(SlotRoomSubject SlotRoomSubject);
        Task UpdateSlotRoomSubjectAsync(SlotRoomSubject SlotRoomSubject);
        Task DeleteSlotRoomSubjectAsync(string id);
    }
}
