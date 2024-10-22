using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class GroupDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public GroupDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Group> GetByIdAsync(string id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task CreateAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}