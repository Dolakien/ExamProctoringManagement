using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class GroupRoomDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public GroupRoomDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<GroupRoom> GetByIdAsync(string id)
        {
            return await _context.GroupRooms.FindAsync(id);
        }

        public async Task<IEnumerable<GroupRoom>> GetAllAsync()
        {
            return await _context.GroupRooms.ToListAsync();
        }

        public async Task CreateAsync(GroupRoom groupRoom)
        {
            await _context.GroupRooms.AddAsync(groupRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GroupRoom groupRoom)
        {
            _context.GroupRooms.Update(groupRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var groupRoom = await _context.GroupRooms.FindAsync(id);
            if (groupRoom != null)
            {
                _context.GroupRooms.Remove(groupRoom);
                await _context.SaveChangesAsync();
            }
        }
    }
}