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
    public class SlotReferenceRepository : ISlotReferenceRepository
    {
        private readonly SlotReferenceDAO _slotReferenceDAO;

        public SlotReferenceRepository(SlotReferenceDAO slotReferenceDAO)
        {
            _slotReferenceDAO = slotReferenceDAO;
        }

        public async Task<SlotReference> GetByIdAsync(string id)
        {
            return await _slotReferenceDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SlotReference>> GetAllAsync()
        {
            return await _slotReferenceDAO.GetAllAsync();
        }

        public async Task CreateAsync(SlotReference slotReference)
        {
            await _slotReferenceDAO.CreateAsync(slotReference);
        }

        public async Task UpdateAsync(SlotReference slotReference)
        {
            await _slotReferenceDAO.UpdateAsync(slotReference);
        }

        public async Task DeleteAsync(string id)
        {
            await _slotReferenceDAO.DeleteAsync(id);
        }
    }
}
