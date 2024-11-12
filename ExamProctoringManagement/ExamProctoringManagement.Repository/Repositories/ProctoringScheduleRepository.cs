using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class ProctoringScheduleRepository : IProctoringScheduleRepository
    {
        private readonly ProctoringScheduleDAO _ProctoringScheduleDAO;

        public ProctoringScheduleRepository(ProctoringScheduleDAO ProctoringScheduleDAO)
        {
            _ProctoringScheduleDAO = ProctoringScheduleDAO;
        }

        public async Task<ProctoringSchedule> GetByIdAsync(string id)
        {
            return await _ProctoringScheduleDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetAllAsync()
        {
            return await _ProctoringScheduleDAO.GetAllAsync();
        }

        public async Task<string> CreateAsync(ProctoringScheduleDTO ProctoringSchedule)
            => await this._ProctoringScheduleDAO.CreateAsync(ProctoringSchedule);
        

        public async Task<string> UpdateAsync(ProctoringScheduleDTO ProctoringSchedule)
            => await this._ProctoringScheduleDAO.UpdateAsync(ProctoringSchedule);
        

        public async Task DeleteAsync(string id)
        {
            await _ProctoringScheduleDAO.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetByUserIdAsync(string userId)
        {
            var schedules = await _ProctoringScheduleDAO.GetAllAsync();
            return schedules.Where(s => s.UserId == userId);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetByUserIdAndIsFinishedAsync(string userId, bool f)
        {
            var schedules = await _ProctoringScheduleDAO.GetAllAsync();
            return schedules.Where(s => s.UserId == userId && s.IsFinished == f);
        }

        public async Task<bool> HasProctoringScheduleAsync(string slotReferenceId)
        {
            var schedules = await _ProctoringScheduleDAO.GetAllAsync();
            foreach (var schedule in schedules)
            {
                if(schedule.SlotReferenceId == slotReferenceId) return true;
            }
            return false;
        }

        public async Task<bool> HasProctoringScheduleWithStatusAsync(string slotReferenceId, bool status)
        {
            var schedules = await _ProctoringScheduleDAO.GetAllAsync();
            foreach (var schedule in schedules)
            {
                if (schedule.SlotReferenceId == slotReferenceId && schedule.Status == status) 
                    return true;
            }
            return false;
        }
    }
}
