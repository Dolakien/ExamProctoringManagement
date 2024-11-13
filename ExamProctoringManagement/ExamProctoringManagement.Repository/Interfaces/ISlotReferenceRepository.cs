using ExamProctoringManagement.Contract.DTOs;
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
        Task<string> CreateAsync(SlotReferenceDTO slotReference);
        Task<string> UpdateAsync(SlotReferenceDTO slotReference);
        Task DeleteAsync(string id);
        Task<IEnumerable<SlotReference>> GetSlotReferencesBySlotAsync(Slot slot);
    }
}
