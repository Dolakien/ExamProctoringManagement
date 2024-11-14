using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupRoomRepository _groupRoomRepository;
        private readonly IRoomRepository _roomRepository;

        public GroupService(IGroupRepository groupRepository, IGroupRoomRepository groupRoomRepository, IRoomRepository roomRepository)
        {
            _groupRepository = groupRepository;
            _groupRoomRepository = groupRoomRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Group> GetGroupByIdAsync(string id)
        {
            return await _groupRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task<Group> CreateGroupAsync(Group group)
        {
            await _groupRepository.CreateAsync(group);
            return group;
        }

        public async Task UpdateGroupAsync(Group group)
        {
            await _groupRepository.UpdateAsync(group);
        }

        public async Task DeleteGroupAsync(string id)
        {
            await _groupRepository.DeleteAsync(id);
        }

        public async Task<Group> CreateGroupAndGroupRoomAsync(CreateGroupAndRoomsRequest createGroupAndRoomsRequest)
        {
            if (createGroupAndRoomsRequest.Group == null)
            {
                return null;
            }
            await _groupRepository.CreateAsync(createGroupAndRoomsRequest.Group);
                GroupRoom groupRoom = new GroupRoom
                {
                    GroupRoomId = "GroupRom" + Guid.NewGuid().ToString().Substring(0, 5),
                    GroupId = createGroupAndRoomsRequest.Group.GroupId,
                    RoomId = createGroupAndRoomsRequest.RoomId
                };
                await _groupRoomRepository.CreateAsync(groupRoom);
            
            return createGroupAndRoomsRequest.Group;
        }

        public async Task<GroupWithListRoomsDto> GetGroupWithListRoomsAsync(string id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            var list = await _groupRoomRepository.GetGroupRoomsByGroupAsync(group);
            if (list.IsNullOrEmpty())
            {
                return null;
            }
            List<Room> rooms = new List<Room>();
            foreach (var groupRoom in list)
            {
                Room room = await _roomRepository.GetByIdAsync(groupRoom.RoomId);
                rooms.Add(room);
            }
            var dto = new GroupWithListRoomsDto();
            dto.rooms = rooms;
            dto.groupId = id;
            return dto;
        }
    }
}
