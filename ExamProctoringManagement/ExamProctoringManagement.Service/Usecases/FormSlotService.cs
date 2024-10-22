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
    public class FormSlotService : IFormSlotService
    {
        private readonly IFormSlotRepository _formSlotRepository;

        public FormSlotService(IFormSlotRepository formSlotRepository)
        {
            _formSlotRepository = formSlotRepository;
        }

        public async Task<FormSlot> GetFormSlotByIdAsync(string id)
        {
            return await _formSlotRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<FormSlot>> GetAllFormSlotsAsync()
        {
            return await _formSlotRepository.GetAllAsync();
        }

        public async Task<FormSlot> CreateFormSlotAsync(FormSlot formSlot)
        {
            await _formSlotRepository.CreateAsync(formSlot);
            return formSlot;
        }

        public async Task UpdateFormSlotAsync(FormSlot formSlot)
        {
            await _formSlotRepository.UpdateAsync(formSlot);
        }

        public async Task DeleteFormSlotAsync(string id)
        {
            await _formSlotRepository.DeleteAsync(id);
        }
    }
}
