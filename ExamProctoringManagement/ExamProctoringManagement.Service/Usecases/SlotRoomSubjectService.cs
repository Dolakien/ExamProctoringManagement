using ExamProctoringManagement.Contract.DTOs;
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

        public async Task<string> CreateSlotRoomSubjectAsync(SlotRoomSubjectDTO SlotRoomSubject)
            => await this._SlotRoomSubjectRepository.CreateAsync(SlotRoomSubject);


        public async Task<string> UpdateSlotRoomSubjectAsync(SlotRoomSubjectDTO SlotRoomSubject)
            => await this._SlotRoomSubjectRepository.UpdateAsync(SlotRoomSubject);

        public async Task DeleteSlotRoomSubjectAsync(string id)
        {
            await _SlotRoomSubjectRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SlotRoomSubject>> GetSlotRoomSubjectsBySlotReferenceIdAsync(string slotReferenceId)
        {
            var slotRoomSubjects = await _SlotRoomSubjectRepository.GetAllAsync();
            var list = new List<SlotRoomSubject>();
            foreach (var slotRoomSubject in slotRoomSubjects)
            {
                if (slotRoomSubject.SlotReferenceId == slotReferenceId)
                {
                    list.Add(slotRoomSubject);
                }
            }
            return list;
        }
    }
}
