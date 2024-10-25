using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class SlotDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public SlotDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<Slot> GetByIdAsync(string id)
        {
            return await _context.Slots.FindAsync(id);
        }

        public async Task<IEnumerable<Slot>> GetAllAsync()
        {
            return await _context.Slots.ToListAsync();
        }

        public async Task CreateAsync(Slot slot)
        {
            await _context.Slots.AddAsync(slot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Slot slot)
        {
            _context.Slots.Update(slot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot != null)
            {
                _context.Slots.Remove(slot);
                await _context.SaveChangesAsync();
            }
        }
    }
}