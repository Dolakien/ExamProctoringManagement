using ExamProctoringManagement.Contract.Payloads.Request;
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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupRoomRepository _groupRoomRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
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
            await _groupRepository.CreateAsync(createGroupAndRoomsRequest.Group);
            foreach (Room room in createGroupAndRoomsRequest.Rooms)
            {
                GroupRoom g = new GroupRoom();
                g.GroupRoomId = createGroupAndRoomsRequest.GroupRoomId;
                g.GroupId = createGroupAndRoomsRequest.Group.GroupId;
                g.RoomId = room.RoomId;
                await _groupRoomRepository.CreateAsync(g);
            }

            return createGroupAndRoomsRequest.Group;
        }
    }

}
