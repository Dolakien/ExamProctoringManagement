using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDAO _RoomDAO;

        public RoomRepository(RoomDAO RoomDAO)
        {
            _RoomDAO = RoomDAO;
        }

        public async Task<Room> GetByIdAsync(string id)
        {
            return await _RoomDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _RoomDAO.GetAllAsync();
        }

        public async Task CreateAsync(Room Room)
        {
            await _RoomDAO.CreateAsync(Room);
        }

        public async Task UpdateAsync(Room Room)
        {
            await _RoomDAO.UpdateAsync(Room);
        }

        public async Task DeleteAsync(string id)
        {
            await _RoomDAO.DeleteAsync(id);
        }
    }
}
