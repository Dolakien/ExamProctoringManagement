using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IProctoringScheduleRepository
    {
        Task<ProctoringSchedule> GetByIdAsync(string id);
        Task<IEnumerable<ProctoringSchedule>> GetAllAsync();
        Task CreateAsync(ProctoringSchedule proctoringSchedule);
        Task UpdateAsync(ProctoringSchedule proctoringSchedule);
        Task DeleteAsync(string id);
    }
}
