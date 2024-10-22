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
    public class RegistrationFormRepository : IRegistrationFormRepository
    {
        private readonly RegistrationFormDAO _RegistrationFormDAO;

        public RegistrationFormRepository(RegistrationFormDAO RegistrationFormDAO)
        {
            _RegistrationFormDAO = RegistrationFormDAO;
        }

        public async Task<RegistrationForm> GetByIdAsync(string id)
        {
            return await _RegistrationFormDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllAsync()
        {
            return await _RegistrationFormDAO.GetAllAsync();
        }

        public async Task CreateAsync(RegistrationForm RegistrationForm)
        {
            await _RegistrationFormDAO.CreateAsync(RegistrationForm);
        }

        public async Task UpdateAsync(RegistrationForm RegistrationForm)
        {
            await _RegistrationFormDAO.UpdateAsync(RegistrationForm);
        }

        public async Task DeleteAsync(string id)
        {
            await _RegistrationFormDAO.DeleteAsync(id);
        }
    }
}
