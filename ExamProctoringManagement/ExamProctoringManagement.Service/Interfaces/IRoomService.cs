using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GetRoomByIdAsync(string id);
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<string> CreateRoomAsync(RoomDTO Room);
        Task<string> UpdateRoomAsync(RoomDTO Room);
        Task DeleteRoomAsync(string id);
    }
}
