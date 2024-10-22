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
    public class GroupRoomService : IGroupRoomService
    {
        private readonly IGroupRoomRepository _GroupRoomRepository;

        public GroupRoomService(IGroupRoomRepository GroupRoomRepository)
        {
            _GroupRoomRepository = GroupRoomRepository;
        }

        public async Task<GroupRoom> GetGroupRoomByIdAsync(string id)
        {
            return await _GroupRoomRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<GroupRoom>> GetAllGroupRoomsAsync()
        {
            return await _GroupRoomRepository.GetAllAsync();
        }

        public async Task<GroupRoom> CreateGroupRoomAsync(GroupRoom GroupRoom)
        {
            await _GroupRoomRepository.CreateAsync(GroupRoom);
            return GroupRoom;
        }

        public async Task UpdateGroupRoomAsync(GroupRoom GroupRoom)
        {
            await _GroupRoomRepository.UpdateAsync(GroupRoom);
        }

        public async Task DeleteGroupRoomAsync(string id)
        {
            await _GroupRoomRepository.DeleteAsync(id);
        }
    }
}
