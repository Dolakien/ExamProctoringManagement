using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
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

        public async Task<string> CreateAsync(SlotRoomSubjectDTO slotRoomSubject)
        {
            var checker = await this._context.SlotRoomSubjects.FirstOrDefaultAsync(x => x.SlotReferenceId == slotRoomSubject.SlotReferenceId);
            if (checker != null)
                return "failed";
            var temp = new SlotRoomSubject()
            {
                SlotRoomSubjectId = "SlotRoomSubject" + Guid.NewGuid().ToString().Substring(0, 5),
                SlotReferenceId = slotRoomSubject.SlotReferenceId,
                SubjectId = slotRoomSubject.SubjectId,
                Status = true,
            };
            await this._context.SlotRoomSubjects.AddAsync(checker);
            await this._context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> UpdateAsync(SlotRoomSubjectDTO slotRoomSubject)
        {
            var checker = await this._context.SlotRoomSubjects.FirstOrDefaultAsync(x => x.SlotReferenceId == slotRoomSubject.SlotReferenceId);
            if (checker == null)
                return "failed";
            checker.SlotReferenceId = slotRoomSubject.SlotReferenceId ?? checker.SlotReferenceId;
            checker.SubjectId = slotRoomSubject.SubjectId ?? checker.SubjectId;
            checker.Status = slotRoomSubject.Status ?? checker.Status;
            this._context.SlotRoomSubjects.Update(checker);
            await this._context.SaveChangesAsync();
            return "Success";
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