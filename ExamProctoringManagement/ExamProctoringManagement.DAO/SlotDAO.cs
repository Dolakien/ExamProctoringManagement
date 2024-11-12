using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<string> CreateAsync(SlotDTO slot)
        {
            var checker = await this._context.Slots.FirstOrDefaultAsync(x => x.SlotId.Equals(slot.SlotId));
            if (checker != null)
                return "failed";
            var temp = new Slot() 
            {
                SlotId = "Slot" + Guid.NewGuid().ToString().Substring(0,5),
                Date = slot.Date,
                Start = slot.Start,
                End = slot.End,
                ExamId = slot.ExamId,
                Status = slot.Status,
            };
            await _context.Slots.AddAsync(temp);
            await _context.SaveChangesAsync();
            return "true";
        }

        public async Task<string> UpdateAsync(SlotDTO slot)
        {
            var checker = await this._context.Slots.FirstOrDefaultAsync(x => x.SlotId.Equals(slot.SlotId));
            if (checker == null)
                return "failed";
            checker.Date = slot.Date;
            checker.Start = slot.Start;
            checker.End = slot.End;
            checker.ExamId = slot.ExamId;
            checker.Status = slot.Status;
            _context.Slots.Update(checker);
            await _context.SaveChangesAsync();
            return "Success";
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