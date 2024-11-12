using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class RoomDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public RoomDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Room> GetByIdAsync(string id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<string> CreateAsync(RoomDTO room)
        {
            var checker = await this._context.Rooms.FirstOrDefaultAsync(x => x.RoomId.Equals(room.RoomId, StringComparison.OrdinalIgnoreCase));
            if (checker == null)
                return "failed";
            var temp = new Room() 
            {
                RoomId = "Room" + Guid.NewGuid().ToString().Substring(0,5),
                RoomName = room.RoomName,
            };
            await this._context.Rooms.AddAsync(temp);
            await this._context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> UpdateAsync(RoomDTO room)
        {
            var checker = await this._context.Rooms.FirstOrDefaultAsync(x => x.RoomId.Equals(room.RoomId, StringComparison.OrdinalIgnoreCase));
            if (checker != null)
                return "failed";
            checker.RoomName = room.RoomName ?? checker.RoomName;
            this._context.Rooms.Update(checker);
            await this._context.SaveChangesAsync();
            return " Success";
        }

        public async Task DeleteAsync(string id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}