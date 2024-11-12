using ExamProctoringManagement.Contract.DTOs;
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
        Task<string> CreateSlotRoomSubjectAsync(SlotRoomSubjectDTO SlotRoomSubject);
        Task<string> UpdateSlotRoomSubjectAsync(SlotRoomSubjectDTO SlotRoomSubject);
        Task DeleteSlotRoomSubjectAsync(string id);
        Task<IEnumerable<SlotRoomSubject>> GetSlotRoomSubjectsBySlotReferenceIdAsync(string slotReferenceId);
    }
}
