using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IProctoringScheduleService
    {
        Task<ProctoringSchedule> GetProctoringScheduleByIdAsync(string id);
        Task<IEnumerable<ProctoringSchedule>> GetAllProctoringSchedulesAsync();
        Task<string> CreateProctoringScheduleAsync(ProctoringScheduleDTO ProctoringSchedule);
        Task<string> UpdateProctoringScheduleAsync(ProctoringScheduleDTO ProctoringSchedule);
        Task DeleteProctoringScheduleAsync(string id);
        Task<IEnumerable<ProctoringSchedule>> GetProctoringSchedulesByUserIdAndIsFinishedAsync(string userId, bool f);
        Task<IEnumerable<ProctoringSchedule>> GetProctoringSchedulesByUserIdAsync(string userId);
        Task<FullProctoringScheduleDto> GetFullProctoringScheduleByIdAsync(string id);
    }
}
