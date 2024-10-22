using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class SemesterDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public SemesterDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Semester> GetByIdAsync(string id)
        {
            return await _context.Semesters.FindAsync(id);
        }

        public async Task<IEnumerable<Semester>> GetAllAsync()
        {
            return await _context.Semesters.ToListAsync();
        }

        public async Task CreateAsync(Semester semester)
        {
            await _context.Semesters.AddAsync(semester);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Semester semester)
        {
            _context.Semesters.Update(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester != null)
            {
                _context.Semesters.Remove(semester);
                await _context.SaveChangesAsync();
            }
        }
    }
}