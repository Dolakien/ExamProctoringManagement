using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface ISlotRoomSubjectRepository
    {
        Task<SlotRoomSubject> GetByIdAsync(string id);
        Task<IEnumerable<SlotRoomSubject>> GetAllAsync();
        Task<string> CreateAsync(SlotRoomSubjectDTO slotRoomSubject);
        Task<string> UpdateAsync(SlotRoomSubjectDTO slotRoomSubject);
        Task DeleteAsync(string id);
    }
}
