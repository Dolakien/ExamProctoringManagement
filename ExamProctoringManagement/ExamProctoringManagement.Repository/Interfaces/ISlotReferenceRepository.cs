using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface ISlotReferenceRepository
    {
        Task<SlotReference> GetByIdAsync(string id);
        Task<IEnumerable<SlotReference>> GetAllAsync();
        Task CreateAsync(SlotReference slotReference);
        Task UpdateAsync(SlotReference slotReference);
        Task DeleteAsync(string id);
        Task<IEnumerable<SlotReference>> GetSlotReferencesBySlotAsync(Slot slot);
    }
}
