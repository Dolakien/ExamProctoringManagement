using ExamProctoringManagement.Contract.DTOs;
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
    public class SlotReferenceService : ISlotReferenceService
    {
        private readonly ISlotReferenceRepository _slotReferenceRepository;
        private readonly IRoomRepository _roomRepository;

        public SlotReferenceService(ISlotReferenceRepository slotReferenceRepository, IRoomRepository roomRepository)
        {
            _slotReferenceRepository = slotReferenceRepository;
            _roomRepository = roomRepository;
        }

        public async Task<SlotReference> GetSlotReferenceByIdAsync(string id)
        {
            return await _slotReferenceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SlotReference>> GetAllSlotReferencesAsync()
        {
            return await _slotReferenceRepository.GetAllAsync();
        }

        public async Task<SlotReference> CreateSlotReferenceAsync(SlotReference slotReference)
        {
            await _slotReferenceRepository.CreateAsync(slotReference);
            return slotReference;
        }

        public async Task UpdateSlotReferenceAsync(SlotReference slotReference)
        {
            await _slotReferenceRepository.UpdateAsync(slotReference);
        }

        public async Task DeleteSlotReferenceAsync(string id)
        {
            await _slotReferenceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SlotReferenceWithRoomDto>> GetSlotReferencesWithRoomAsync()
        {
            var slotReferences = await _slotReferenceRepository.GetAllAsync();
            List<SlotReferenceWithRoomDto> dtos = new List<SlotReferenceWithRoomDto>();
            foreach (var slotReference in slotReferences)
            {
                if (slotReference.RoomId != null)
                {
                    var room = await _roomRepository.GetByIdAsync(slotReference.RoomId);
                    SlotReferenceWithRoomDto dto = new SlotReferenceWithRoomDto();
                    dto.SlotReferenceId = slotReference.SlotReferenceId;
                    dto.SlotId = slotReference.SlotId;
                    dto.RoomId = slotReference.RoomId;
                    dto.RoomName = room.RoomName;
                    dtos.Add(dto);
                }
            }

            return dtos;
        }
    }
}

