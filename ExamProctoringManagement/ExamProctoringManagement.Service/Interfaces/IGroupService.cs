using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IGroupService
    {
        Task<Group> GetGroupByIdAsync(string id);
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(string id);
        Task<Group> CreateGroupAndGroupRoomAsync(CreateGroupAndRoomsRequest createGroupAndRoomsRequest);
        Task<GroupWithListRoomsDto> GetGroupWithListRoomsAsync(string id);
    }
}
