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
    public class FormSwapRepository : IFormSwapRepository
    {
        private readonly FormSwapDAO _formSwapDAO;

        public FormSwapRepository(FormSwapDAO formSwapDAO)
        {
            _formSwapDAO = formSwapDAO;
        }

        public async Task<FormSwap> GetByIdAsync(string id)
        {
            return await _formSwapDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<FormSwap>> GetAllAsync()
        {
            return await _formSwapDAO.GetAllAsync();
        }

        public async Task CreateAsync(FormSwap formSwap)
        {
            await _formSwapDAO.CreateAsync(formSwap);
        }

        public async Task UpdateAsync(FormSwap formSwap)
        {
            await _formSwapDAO.UpdateAsync(formSwap);
        }

        public async Task DeleteAsync(string id)
        {
            await _formSwapDAO.DeleteAsync(id);
        }
    }
}
