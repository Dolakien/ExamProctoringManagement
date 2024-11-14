using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class ExamDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public ExamDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Exam> GetByIdAsync(string id)
        {
            return await _context.Exams.FindAsync(id);
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<string> CreateAsync(ExamDTO exam)
        {
            var checker = await this._context.Exams.FirstOrDefaultAsync(x => x.ExamId.Equals(exam.ExamId));
            if (checker != null)
                return "failed";
            var temp = new Exam()
            {
                ExamId = exam.ExamId,
                ExamName = exam.ExamName,
                ToDate = exam.ToDate,
                Type = exam.Type,
                FromDate = exam.FromDate,
                SemesterId = exam.SemesterId,
                Status = true,
            };

            await this._context.Exams.AddAsync(temp);
            await this._context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> UpdateAsync(ExamDTO exam)
        {
            var checker = await this._context.Exams.FirstOrDefaultAsync(x => x.ExamId.Equals(exam.ExamId));
            if (checker == null)
                return "failed";
            checker.ExamName = exam.ExamName ?? checker.ExamName;
            checker.ToDate = exam.ToDate ?? checker.ToDate;
            checker.Type = exam.Type ?? checker.Type;
            checker.FromDate = exam.FromDate ?? checker.FromDate;
            checker.SemesterId = exam.SemesterId ?? checker.SemesterId;
            checker.Status = exam.Status ?? checker.Status;
            this._context.Exams.Update(checker);
            await this._context.SaveChangesAsync();
            return "Success";
        }

        public async Task DeleteAsync(string id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();
            }
        }
    }
}
