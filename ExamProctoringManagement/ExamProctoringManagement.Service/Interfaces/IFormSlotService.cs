using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IFormSlotService
    {
        Task<FormSlot> GetFormSlotByIdAsync(string id);
        Task<IEnumerable<FormSlot>> GetAllFormSlotsAsync();
        Task<FormSlot> CreateFormSlotAsync(FormSlot formSlot);
        Task<FormSlot> UpdateFormSlotAsync(FormSlotUpdateDto formSlot);
        Task DeleteFormSlotAsync(string id);
    }
}
