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
        Task CreateAsync(SlotRoomSubject slotRoomSubject);
        Task UpdateAsync(SlotRoomSubject slotRoomSubject);
        Task DeleteAsync(string id);
    }
}
