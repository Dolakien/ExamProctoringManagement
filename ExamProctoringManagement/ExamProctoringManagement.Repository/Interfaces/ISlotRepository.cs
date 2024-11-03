using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface ISlotRepository
    {
        Task<Slot> GetByIdAsync(string id);
        Task<IEnumerable<Slot>> GetAllAsync();
        Task CreateAsync(Slot slot);
        Task UpdateAsync(Slot slot);
        Task DeleteAsync(string id);
        Task<IEnumerable<Slot>> GetSlotsByExamAsync(Exam exam);
    }
}
