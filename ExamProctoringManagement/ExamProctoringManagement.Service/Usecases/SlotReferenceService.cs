using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
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
        private readonly ISlotRepository _slotRepository;
        private readonly IProctoringScheduleRepository _proctoringScheduleRepository;
        private readonly IExamRepository _examRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupRoomRepository _groupRoomRepository;

        public SlotReferenceService(ISlotReferenceRepository slotReferenceRepository, IRoomRepository roomRepository, 
            ISlotRepository slotRepository, IProctoringScheduleRepository proctoringScheduleRepository, IExamRepository examRepository,
            IGroupRepository groupRepository, IGroupRoomRepository groupRoomRepository)
        {
            _slotReferenceRepository = slotReferenceRepository;
            _roomRepository = roomRepository;
            _slotRepository = slotRepository;
            _proctoringScheduleRepository = proctoringScheduleRepository;
            _examRepository = examRepository;
            _groupRepository = groupRepository;
            _groupRoomRepository = groupRoomRepository;
        }

        public async Task<SlotReference> GetSlotReferenceByIdAsync(string id)
        {
            return await _slotReferenceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SlotReference>> GetAllSlotReferencesAsync()
        {
            return await _slotReferenceRepository.GetAllAsync();
        }

        public async Task<string> CreateSlotReferenceAsync(SlotReferenceDTO slotReference)
            => await this._slotReferenceRepository.CreateAsync(slotReference);


        public async Task<string> UpdateSlotReferenceAsync(SlotReferenceDTO slotReference)
            => await this._slotReferenceRepository.UpdateAsync(slotReference);

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

        public async Task<IEnumerable<SlotReference>> GetSlotReferencesBySlotIdAsync(string slotId)
        {
            return await _slotReferenceRepository.
                GetSlotReferencesBySlotAsync(await _slotRepository.GetByIdAsync(slotId));
        }

        public async Task<IEnumerable<SlotReferenceWithRoomDto>> GetSlotReferencesWithRoomAsync(string examId)
        {
            var slots = await _slotRepository.GetSlotsByExamAsync(await _examRepository.GetByIdAsync(examId));

            var slotReferences = await _slotReferenceRepository.GetAllAsync();
            List<SlotReferenceWithRoomDto> dtos = new List<SlotReferenceWithRoomDto>();
            foreach (var s in slots)
            {
                foreach (var slotReference in slotReferences)
                {
                    if (slotReference.RoomId != null && slotReference.SlotId == s.SlotId
                        && !await _proctoringScheduleRepository.HasProctoringScheduleWithStatusAsync(slotReference.SlotReferenceId, true))
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
            }

            return dtos;
        }

        public async Task<IEnumerable<SlotReferenceWithGroupDto>> GetSlotReferencesWithGroupAsync(string examId)
        {
            var slots = await _slotRepository.GetSlotsByExamAsync(await _examRepository.GetByIdAsync(examId));

            var slotReferences = await _slotReferenceRepository.GetAllAsync();
            List<SlotReferenceWithGroupDto> dtos = new List<SlotReferenceWithGroupDto>();
            foreach (var s in slots)
            {
                foreach (var slotReference in slotReferences)
                {
                    if (slotReference.GroupId != null && slotReference.SlotId == s.SlotId
                        && !await _proctoringScheduleRepository.HasProctoringScheduleWithStatusAsync(slotReference.SlotReferenceId, true))
                    { 
                        var group = await _groupRepository.GetByIdAsync(slotReference.GroupId);
                        var list = await _groupRoomRepository.GetGroupRoomsByGroupAsync(group);
                        List<Room> rooms = new List<Room>();
                        foreach (var groupRoom in list)
                        {
                            Room room = await _roomRepository.GetByIdAsync(groupRoom.RoomId);
                            rooms.Add(room);
                        }

                        SlotReferenceWithGroupDto dto = new SlotReferenceWithGroupDto();
                        dto.SlotReferenceId = slotReference.SlotReferenceId;
                        dto.SlotId = slotReference.SlotId;
                        dto.GroupId = slotReference.GroupId;
                        dto.Rooms = rooms;
                        dtos.Add(dto);
                    }
                }
            }

            return dtos;
        }
    }
}

