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
    public class FormSwapService : IFormSwapService
    {
        private readonly IFormSwapRepository _formSwapRepository;

        public FormSwapService(IFormSwapRepository formSwapRepository)
        {
            _formSwapRepository = formSwapRepository;
        }

        public async Task<FormSwap> GetFormSwapByIdAsync(string id)
        {
            return await _formSwapRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<FormSwap>> GetAllFormSwapsAsync()
        {
            return await _formSwapRepository.GetAllAsync();
        }

        public async Task<FormSwap> CreateFormSwapAsync(FormSwap formSwap)
        {
            await _formSwapRepository.CreateAsync(formSwap);
            return formSwap;
        }

        public async Task UpdateFormSwapAsync(FormSwap formSwap)
        {
            await _formSwapRepository.UpdateAsync(formSwap);
        }

        public async Task DeleteFormSwapAsync(string id)
        {
            await _formSwapRepository.DeleteAsync(id);
        }
    }
}
