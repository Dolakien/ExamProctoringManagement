using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ProctoringScheduleProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
