using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
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

        public async Task<string> CreateAsync(SlotReferenceDTO slotReference)
        {
            var checker = await this._context.SlotReferences.FirstOrDefaultAsync(x => x.SlotReferenceId == slotReference.SlotReferenceId);
            if (checker != null)
                return "failed";
            var temp = new SlotReference()
            {
                SlotReferenceId = "SlotReference" + Guid.NewGuid().ToString().Substring(0,5),
                SlotId = slotReference.SlotId,
                RoomId = slotReference.RoomId,
                GroupId = slotReference.GroupId,
            };
            await this._context.SlotReferences.AddAsync(temp);
            await this._context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> UpdateAsync(SlotReferenceDTO slotReference)
        {
            var checker = await this._context.SlotReferences.FirstOrDefaultAsync(x => x.SlotReferenceId == slotReference.SlotReferenceId);
            if (checker == null)
                return "failed";
            checker.SlotId = slotReference.SlotId ?? checker.SlotId;
            checker.RoomId = slotReference.RoomId ?? checker.RoomId;
            checker.GroupId = slotReference.GroupId ?? checker.GroupId;
            this._context.SlotReferences.Update(checker);
            await _context.SaveChangesAsync();
            return "Success";
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