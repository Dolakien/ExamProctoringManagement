using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class FormSwapDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public FormSwapDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<FormSwap> GetByIdAsync(string id)
        {
            return await _context.FormSwaps.FindAsync(id);
        }

        public async Task<IEnumerable<FormSwap>> GetAllAsync()
        {
            return await _context.FormSwaps.ToListAsync();
        }

        public async Task CreateAsync(FormSwap formSwap)
        {
            await _context.FormSwaps.AddAsync(formSwap);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FormSwap formSwap)
        {
            _context.FormSwaps.Update(formSwap);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var formSwap = await _context.FormSwaps.FindAsync(id);
            if (formSwap != null)
            {
                _context.FormSwaps.Remove(formSwap);
                await _context.SaveChangesAsync();
            }
        }
    }
}