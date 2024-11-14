using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class ProctoringScheduleDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public ProctoringScheduleDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<ProctoringSchedule> GetByIdAsync(string id)
        {
            return await _context.ProctoringSchedules.FindAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetAllAsync()
        {
            return await _context.ProctoringSchedules.ToListAsync();
        }

        public async Task<string> CreateAsync(ProctoringScheduleDTO proctoringSchedule)
        {
            var checker = await this._context.ProctoringSchedules.Where(x => x.ScheduleId.Equals(proctoringSchedule.ScheduleId)).FirstOrDefaultAsync();
            if (checker != null)
                return "failed";
            var temp = new ProctoringSchedule()
            {
                ScheduleId = "Schedule" + proctoringSchedule.ScheduleId,
                IsFinished = proctoringSchedule.IsFinished,
                UserId = proctoringSchedule.UserId,
                ProctorType = proctoringSchedule.ProctorType,
                SlotReferenceId = proctoringSchedule.SlotReferenceId,
                Status = true,
            };
            await this._context.ProctoringSchedules.AddAsync(temp);
            await this._context.SaveChangesAsync();
            return "success";
        }

        public async Task<string> UpdateAsync(ProctoringScheduleDTO proctoringSchedule)
        {
            var checker = await this._context.ProctoringSchedules.Where(x => x.ScheduleId.Equals(proctoringSchedule.ScheduleId)).FirstOrDefaultAsync();
            if (checker == null)
                return "failed";
            checker.IsFinished = proctoringSchedule.IsFinished ?? checker.IsFinished;
            checker.UserId = proctoringSchedule.UserId ?? checker.UserId;
            checker.ProctorType = proctoringSchedule.ProctorType ?? checker.ProctorType;
            checker.SlotReferenceId = proctoringSchedule.SlotReferenceId ?? checker.SlotReferenceId;
            checker.Status = proctoringSchedule.Status ?? checker.Status;
            this._context.ProctoringSchedules.Update(checker);
            await this._context.SaveChangesAsync();
            return "success";
        }

        public async Task DeleteAsync(string id)
        {
            var proctoringSchedule = await _context.ProctoringSchedules.FindAsync(id);
            if (proctoringSchedule != null)
            {
                _context.ProctoringSchedules.Remove(proctoringSchedule);
                await _context.SaveChangesAsync();
            }
        }
    }
}