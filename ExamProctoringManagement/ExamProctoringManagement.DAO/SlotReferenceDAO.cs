using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class SlotReferenceDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public SlotReferenceDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<SlotReference> GetByIdAsync(string id)
        {
            return await _context.SlotReferences.FindAsync(id);
        }

        public async Task<IEnumerable<SlotReference>> GetAllAsync()
        {
            return await _context.SlotReferences.ToListAsync();
        }

        public async Task CreateAsync(SlotReference slotReference)
        {
            await _context.SlotReferences.AddAsync(slotReference);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SlotReference slotReference)
        {
            _context.SlotReferences.Update(slotReference);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var slotReference = await _context.SlotReferences.FindAsync(id);
            if (slotReference != null)
            {
                _context.SlotReferences.Remove(slotReference);
                await _context.SaveChangesAsync();
            }
        }
    }
}