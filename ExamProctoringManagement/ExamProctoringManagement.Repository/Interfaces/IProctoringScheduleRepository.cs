using ExamProctoringManagement.Contract.DTOs;
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
        Task<string> CreateAsync(ProctoringScheduleDTO proctoringSchedule);
        Task<string> UpdateAsync(ProctoringScheduleDTO proctoringSchedule);
        Task DeleteAsync(string id);
        Task<IEnumerable<ProctoringSchedule>> GetByUserIdAsync(string userId);
        Task<IEnumerable<ProctoringSchedule>> GetByUserIdAndIsFinishedAsync(string userId, bool f);
        Task<bool> HasProctoringScheduleAsync(string slotReferenceId);
        Task<bool> HasProctoringScheduleWithStatusAsync(string slotReferenceId, bool status);
        Task CountProctoringAsync(string id);

    }
}
