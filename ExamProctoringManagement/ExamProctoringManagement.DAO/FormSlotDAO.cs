using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class FormSlotDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public FormSlotDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<FormSlot> GetByIdAsync(string id)
        {
            return await _context.FormSlots.FindAsync(id);
        }

        public async Task<IEnumerable<FormSlot>> GetAllAsync()
        {
            return await _context.FormSlots.ToListAsync();
        }

        public async Task CreateAsync(FormSlot formSlot)
        {
            await _context.FormSlots.AddAsync(formSlot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FormSlot formSlot)
        {
            _context.FormSlots.Update(formSlot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var formSlot = await _context.FormSlots.FindAsync(id);
            if (formSlot != null)
            {
                _context.FormSlots.Remove(formSlot);
                await _context.SaveChangesAsync();
            }
        }
    }
}