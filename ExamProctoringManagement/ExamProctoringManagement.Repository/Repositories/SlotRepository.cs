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
    public class SlotRepository : ISlotRepository
    {
        private readonly SlotDAO _SlotDAO;

        public SlotRepository(SlotDAO SlotDAO)
        {
            _SlotDAO = SlotDAO;
        }

        public async Task<Slot> GetByIdAsync(string id)
        {
            return await _SlotDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Slot>> GetAllAsync()
        {
            return await _SlotDAO.GetAllAsync();
        }

        public async Task CreateAsync(Slot Slot)
        {
            await _SlotDAO.CreateAsync(Slot);
        }

        public async Task UpdateAsync(Slot Slot)
        {
            await _SlotDAO.UpdateAsync(Slot);
        }

        public async Task DeleteAsync(string id)
        {
            await _SlotDAO.DeleteAsync(id);
        }
    }
}
