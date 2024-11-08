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
    public class FormSlotRepository : IFormSlotRepository
    {
        private readonly FormSlotDAO _formSlotDAO;

        public FormSlotRepository(FormSlotDAO formSlotDAO)
        {
            _formSlotDAO = formSlotDAO;
        }

        public async Task<FormSlot> GetByIdAsync(string id)
        {
            return await _formSlotDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<FormSlot>> GetAllAsync()
        {
            return await _formSlotDAO.GetAllAsync();
        }

        public async Task CreateAsync(FormSlot formSlot)
        {
            await _formSlotDAO.CreateAsync(formSlot);
        }

        public async Task UpdateAsync(FormSlot formSlot)
        {
            await _formSlotDAO.UpdateAsync(formSlot);
        }

        public async Task DeleteAsync(string id)
        {
            await _formSlotDAO.DeleteAsync(id);
        }

        public async Task<IEnumerable<FormSlot>> GetFormSlotsByRegisFormAsync(RegistrationForm registrationForm)
        {
            if (registrationForm == null)
            {
                return Enumerable.Empty<FormSlot>();
            }
            var formSlots = _formSlotDAO.GetAllAsync();
            var list = new List<FormSlot>();
            if (formSlots != null)
            {
                foreach (var formSlot in await formSlots)
                {
                    if (formSlot.FormId == registrationForm.FormId)
                        list.Add(formSlot);
                }
            }
            return list;
        }
    }
}
