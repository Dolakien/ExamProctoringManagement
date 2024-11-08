using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IFormSlotRepository
    {
        Task<FormSlot> GetByIdAsync(string id);
        Task<IEnumerable<FormSlot>> GetAllAsync();
        Task CreateAsync(FormSlot formSlot);
        Task UpdateAsync(FormSlot formSlot);
        Task DeleteAsync(string id);
        Task<IEnumerable<FormSlot>> GetFormSlotsByRegisFormAsync(RegistrationForm registrationForm);
    }
}
