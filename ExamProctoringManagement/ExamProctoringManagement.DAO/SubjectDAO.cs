using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class SubjectDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public SubjectDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetByIdAsync(string id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<string> CreateAsync(SubjectDto subject)
        {
            var checker = await this._context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == subject.SubjectId);
            if (checker != null)
                return "failed";
            var temp = new Subject()
            {
                SubjectId = "Subject" + Guid.NewGuid().ToString().Substring(0, 5),
                ExamId = subject.SubjectId,
                SubjectName = subject.SubjectName,
            };
            await this._context.Subjects.AddAsync(temp);
            await this._context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> UpdateAsync(SubjectDto subject)
        {
            var checker = await this._context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == subject.SubjectId);
            if (checker == null)
                return "failed";
            checker.SubjectName = subject.SubjectName ?? checker.SubjectName;
            checker.ExamId = subject.ExamId ?? checker.ExamId;
            this._context.Subjects.Update(checker);
            await this._context.SaveChangesAsync();
            return "Success";
        }
        public async Task DeleteAsync(string id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
    }
}