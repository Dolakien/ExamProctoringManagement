using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _SlotRepository;

        public SlotService(ISlotRepository SlotRepository)
        {
            _SlotRepository = SlotRepository;
        }

        public async Task<Slot> GetSlotByIdAsync(string id)
        {
            return await _SlotRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Slot>> GetAllSlotsAsync()
        {
            return await _SlotRepository.GetAllAsync();
        }

        public async Task<Slot> CreateSlotAsync(Slot Slot)
        {
            await _SlotRepository.CreateAsync(Slot);
            return Slot;
        }

        public async Task UpdateSlotAsync(Slot Slot)
        {
            await _SlotRepository.UpdateAsync(Slot);
        }

        public async Task DeleteSlotAsync(string id)
        {
            await _SlotRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Slot>> GetSlotsByExamIdAsync(string examId)
        {
            var slots = await _SlotRepository.GetAllAsync();
            var list = new List<Slot>();
            foreach (var slot in slots)
            {
                if (slot.ExamId == examId)
                {
                    list.Add(slot);
                }
            }
            return list;
        }
    }
}
