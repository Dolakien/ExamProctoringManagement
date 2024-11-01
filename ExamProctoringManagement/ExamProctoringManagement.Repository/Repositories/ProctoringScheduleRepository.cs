using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;

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

        public async Task CreateAsync(ProctoringSchedule ProctoringSchedule)
        {
            await _ProctoringScheduleDAO.CreateAsync(ProctoringSchedule);
        }

        public async Task UpdateAsync(ProctoringSchedule ProctoringSchedule)
        {
            await _ProctoringScheduleDAO.UpdateAsync(ProctoringSchedule);
        }

        public async Task DeleteAsync(string id)
        {
            await _ProctoringScheduleDAO.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetByUserIdAsync(string userId)
        {
            var schedules = await _ProctoringScheduleDAO.GetAllAsync();
            return schedules.Where(s => s.UserId == userId);
        }
    }
}
