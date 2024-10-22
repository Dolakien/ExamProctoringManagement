using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IFormSwapService
    {
        Task<FormSwap> GetFormSwapByIdAsync(string id);
        Task<IEnumerable<FormSwap>> GetAllFormSwapsAsync();
        Task<FormSwap> CreateFormSwapAsync(FormSwap formSwap);
        Task UpdateFormSwapAsync(FormSwap formSwap);
        Task DeleteFormSwapAsync(string id);
    }
}
