using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamDAO _examDAO;

        public ExamRepository(ExamDAO examDAO)
        {
            _examDAO = examDAO;
        }

        public async Task<Exam> GetByIdAsync(string id)
        {
            return await _examDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _examDAO.GetAllAsync();
        }

        public async Task CreateAsync(Exam exam)
        {
            await _examDAO.CreateAsync(exam);
        }

        public async Task UpdateAsync(Exam exam)
        {
            await _examDAO.UpdateAsync(exam);
        }

        public async Task DeleteAsync(string id)
        {
            await _examDAO.DeleteAsync(id);
        }
    }
}
