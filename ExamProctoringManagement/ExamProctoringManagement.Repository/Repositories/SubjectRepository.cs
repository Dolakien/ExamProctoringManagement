using ExamProctoringManagement.Contract.DTOs;
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

        public async Task<string> CreateAsync(SubjectDto Subject)
             => await this._SubjectDAO.CreateAsync(Subject);


        public async Task<string> UpdateAsync(SubjectDto Subject)
            => await this._SubjectDAO.UpdateAsync(Subject);


        public async Task DeleteAsync(string id)
        {
            await _SubjectDAO.DeleteAsync(id);
        }
    }
}
