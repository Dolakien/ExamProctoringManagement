using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IGroupRoomService
    {
        Task<GroupRoom> GetGroupRoomByIdAsync(string id);
        Task<IEnumerable<GroupRoom>> GetAllGroupRoomsAsync();
        Task<GroupRoom> CreateGroupRoomAsync(GroupRoom GroupRoom);
        Task UpdateGroupRoomAsync(GroupRoom GroupRoom);
        Task DeleteGroupRoomAsync(string id);
    }
}
