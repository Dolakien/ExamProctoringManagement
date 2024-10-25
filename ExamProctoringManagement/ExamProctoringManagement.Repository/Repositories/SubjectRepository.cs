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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SubjectDAO _SubjectDAO;

        public SubjectRepository(SubjectDAO SubjectDAO)
        {
            _SubjectDAO = SubjectDAO;
        }

        public async Task<Subject> GetByIdAsync(string id)
        {
            return await _SubjectDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _SubjectDAO.GetAllAsync();
        }

        public async Task CreateAsync(Subject Subject)
        {
            await _SubjectDAO.CreateAsync(Subject);
        }

        public async Task UpdateAsync(Subject Subject)
        {
            await _SubjectDAO.UpdateAsync(Subject);
        }

        public async Task DeleteAsync(string id)
        {
            await _SubjectDAO.DeleteAsync(id);
        }
    }
}
