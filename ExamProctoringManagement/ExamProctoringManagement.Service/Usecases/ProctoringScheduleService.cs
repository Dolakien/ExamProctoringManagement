using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class ProctoringScheduleService : IProctoringScheduleService
    {
        private readonly IProctoringScheduleRepository _ProctoringScheduleRepository;

        public ProctoringScheduleService(IProctoringScheduleRepository ProctoringScheduleRepository)
        {
            _ProctoringScheduleRepository = ProctoringScheduleRepository;
        }

        public async Task<ProctoringSchedule> GetProctoringScheduleByIdAsync(string id)
        {
            return await _ProctoringScheduleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetAllProctoringSchedulesAsync()
        {
            return await _ProctoringScheduleRepository.GetAllAsync();
        }

        public async Task<ProctoringSchedule> CreateProctoringScheduleAsync(ProctoringSchedule ProctoringSchedule)
        {
            await _ProctoringScheduleRepository.CreateAsync(ProctoringSchedule);
            return ProctoringSchedule;
        }

        public async Task UpdateProctoringScheduleAsync(ProctoringSchedule ProctoringSchedule)
        {
            await _ProctoringScheduleRepository.UpdateAsync(ProctoringSchedule);
        }

        public async Task DeleteProctoringScheduleAsync(string id)
        {
            await _ProctoringScheduleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetProctoringSchedulesByUserIdAsync(string userId)
        {
            return await _ProctoringScheduleRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetProctoringSchedulesByUserIdAndIsFinishedAsync(string userId, bool f)
        {
            return await _ProctoringScheduleRepository.GetByUserIdAndIsFinishedAsync(userId, f);
        }
    }
}
