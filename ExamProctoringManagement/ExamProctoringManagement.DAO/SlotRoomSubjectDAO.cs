using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class SlotRoomSubjectDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public SlotRoomSubjectDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<SlotRoomSubject> GetByIdAsync(string id)
        {
            return await _context.SlotRoomSubjects.FindAsync(id);
        }

        public async Task<IEnumerable<SlotRoomSubject>> GetAllAsync()
        {
            return await _context.SlotRoomSubjects.ToListAsync();
        }

        public async Task CreateAsync(SlotRoomSubject slotRoomSubject)
        {
            await _context.SlotRoomSubjects.AddAsync(slotRoomSubject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SlotRoomSubject slotRoomSubject)
        {
            _context.SlotRoomSubjects.Update(slotRoomSubject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var slotRoomSubject = await _context.SlotRoomSubjects.FindAsync(id);
            if (slotRoomSubject != null)
            {
                _context.SlotRoomSubjects.Remove(slotRoomSubject);
                await _context.SaveChangesAsync();
            }
        }
    }
}