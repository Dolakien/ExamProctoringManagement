using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class ProctoringScheduleDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public ProctoringScheduleDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<ProctoringSchedule> GetByIdAsync(string id)
        {
            return await _context.ProctoringSchedules.FindAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetAllAsync()
        {
            return await _context.ProctoringSchedules.ToListAsync();
        }

        public async Task CreateAsync(ProctoringSchedule proctoringSchedule)
        {
            await _context.ProctoringSchedules.AddAsync(proctoringSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProctoringSchedule proctoringSchedule)
        {
            _context.ProctoringSchedules.Update(proctoringSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var proctoringSchedule = await _context.ProctoringSchedules.FindAsync(id);
            if (proctoringSchedule != null)
            {
                _context.ProctoringSchedules.Remove(proctoringSchedule);
                await _context.SaveChangesAsync();
            }
        }
    }
}