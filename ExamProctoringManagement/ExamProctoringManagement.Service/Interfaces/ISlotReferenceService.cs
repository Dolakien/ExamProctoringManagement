using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface ISlotReferenceService
    {
        Task<SlotReference> GetSlotReferenceByIdAsync(string id);
        Task<IEnumerable<SlotReference>> GetAllSlotReferencesAsync();
        Task<SlotReference> CreateSlotReferenceAsync(SlotReference slotReference);
        Task UpdateSlotReferenceAsync(SlotReference slotReference);
        Task DeleteSlotReferenceAsync(string id);
        Task<IEnumerable<SlotReferenceWithRoomDto>> GetSlotReferencesWithRoomAsync();
        Task<IEnumerable<SlotReference>> GetSlotReferencesBySlotIdAsync(string slotId);
        Task<IEnumerable<SlotReferenceWithRoomDto>> GetSlotReferencesWithRoomAsync(string examId);
        Task<IEnumerable<SlotReferenceWithGroupDto>> GetSlotReferencesWithGroupAsync(string examId);
    }
}
