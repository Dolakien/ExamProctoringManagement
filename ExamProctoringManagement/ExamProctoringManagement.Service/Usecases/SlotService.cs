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
        private readonly IExamRepository _ExamRepository;
        private readonly ISlotReferenceRepository _SlotReferenceRepository;
        private readonly IProctoringScheduleRepository _ProctoringScheduleRepository;

        public SlotService(ISlotRepository SlotRepository, IExamRepository examRepository, 
            ISlotReferenceRepository slotReferenceRepository, 
            IProctoringScheduleRepository proctoringScheduleRepository)
        {
            _SlotRepository = SlotRepository;
            _ExamRepository = examRepository;
            _SlotReferenceRepository = slotReferenceRepository;
            _ProctoringScheduleRepository = proctoringScheduleRepository;
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
            return await _SlotRepository.GetSlotsByExamAsync(await _ExamRepository.GetByIdAsync(examId));
        }

        public async Task<IEnumerable<Slot>> GetAvailableSlotsByExamId(string examId)
        {
            var slots = await _SlotRepository.GetSlotsByExamAsync(await _ExamRepository.GetByIdAsync(examId));
            var availableSlots = new List<Slot>();

            foreach (var slot in slots)
            {
                var slotReferences = await _SlotReferenceRepository.GetSlotReferencesBySlotAsync(slot);

                var hasUnscheduledSlotReference = slotReferences.Any(slotRef =>
                    !_ProctoringScheduleRepository.HasProctoringScheduleAsync(slotRef.SlotReferenceId).Result);

                if (hasUnscheduledSlotReference)
                {
                    availableSlots.Add(slot);
                }
            }

            return availableSlots;
        }
    }
}
