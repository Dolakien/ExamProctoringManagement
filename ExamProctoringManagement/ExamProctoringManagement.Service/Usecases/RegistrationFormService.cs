using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRegistrationFormRepository _RegistrationFormRepository;

        public RegistrationFormService(IRegistrationFormRepository RegistrationFormRepository)
        {
            _RegistrationFormRepository = RegistrationFormRepository;
        }

        public async Task<RegistrationForm> GetRegistrationFormByIdAsync(string id)
        {
            return await _RegistrationFormRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllRegistrationFormsAsync()
        {
            return await _RegistrationFormRepository.GetAllAsync();
        }

        public async Task<RegistrationForm> CreateRegistrationFormAsync(RegistrationForm RegistrationForm)
        {
            await _RegistrationFormRepository.CreateAsync(RegistrationForm);
            return RegistrationForm;
        }

        public async Task UpdateRegistrationFormAsync(RegistrationForm RegistrationForm)
        {
            await _RegistrationFormRepository.UpdateAsync(RegistrationForm);
        }

        public async Task DeleteRegistrationFormAsync(string id)
        {
            await _RegistrationFormRepository.DeleteAsync(id);
        }
    }

}
