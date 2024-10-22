using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IFormSwapRepository
    {
        Task<FormSwap> GetByIdAsync(string id);
        Task<IEnumerable<FormSwap>> GetAllAsync();
        Task CreateAsync(FormSwap formSwap);
        Task UpdateAsync(FormSwap formSwap);
        Task DeleteAsync(string id);
    }
}
