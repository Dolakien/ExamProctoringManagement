using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> GetByIdAsync(string id);
        Task<IEnumerable<Report>> GetAllAsync();
        Task CreateAsync(Report report);
        Task UpdateAsync(Report report);
        Task DeleteAsync(string id);
    }
}
