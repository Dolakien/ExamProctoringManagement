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
    public class SemesterRepository : ISemesterRepository
    {
        private readonly SemesterDAO _SemesterDAO;

        public SemesterRepository(SemesterDAO SemesterDAO)
        {
            _SemesterDAO = SemesterDAO;
        }

        public async Task<Semester> GetByIdAsync(string id)
        {
            return await _SemesterDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Semester>> GetAllAsync()
        {
            return await _SemesterDAO.GetAllAsync();
        }

        public async Task CreateAsync(Semester Semester)
        {
            await _SemesterDAO.CreateAsync(Semester);
        }

        public async Task UpdateAsync(Semester Semester)
        {
            await _SemesterDAO.UpdateAsync(Semester);
        }

        public async Task DeleteAsync(string id)
        {
            await _SemesterDAO.DeleteAsync(id);
        }
    }
}
