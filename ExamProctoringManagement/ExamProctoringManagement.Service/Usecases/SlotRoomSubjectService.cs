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
    public class SlotRoomSubjectService : ISlotRoomSubjectService
    {
        private readonly ISlotRoomSubjectRepository _SlotRoomSubjectRepository;

        public SlotRoomSubjectService(ISlotRoomSubjectRepository SlotRoomSubjectRepository)
        {
            _SlotRoomSubjectRepository = SlotRoomSubjectRepository;
        }

        public async Task<SlotRoomSubject> GetSlotRoomSubjectByIdAsync(string id)
        {
            return await _SlotRoomSubjectRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SlotRoomSubject>> GetAllSlotRoomSubjectsAsync()
        {
            return await _SlotRoomSubjectRepository.GetAllAsync();
        }

        public async Task<SlotRoomSubject> CreateSlotRoomSubjectAsync(SlotRoomSubject SlotRoomSubject)
        {
            await _SlotRoomSubjectRepository.CreateAsync(SlotRoomSubject);
            return SlotRoomSubject;
        }

        public async Task UpdateSlotRoomSubjectAsync(SlotRoomSubject SlotRoomSubject)
        {
            await _SlotRoomSubjectRepository.UpdateAsync(SlotRoomSubject);
        }

        public async Task DeleteSlotRoomSubjectAsync(string id)
        {
            await _SlotRoomSubjectRepository.DeleteAsync(id);
        }
    }

}
