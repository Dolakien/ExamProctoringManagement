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
            return await _context.ProctoringSchedules.FirstOrDefaultAsync(p => p.ScheduleId == id);
        }


        public async Task<IEnumerable<ProctoringSchedule>> GetAllAsync()
        {
            return await _context.ProctoringSchedules.ToListAsync();
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetAllTrueStatus()
        {
            return await _context.ProctoringSchedules
                                 .Where(ps => ps.Status == true && ps.IsFinished == false) // Thêm điều kiện isFinished = false
                                 .ToListAsync();
        }


        public async Task<string> CreateAsync(CreateProctoringRequest proctoringSchedule, string userId)
        {
            var temp = new ProctoringSchedule()
            {
                ScheduleId = "Schedule" + Guid.NewGuid().ToString().Substring(0, 4),
                IsFinished = false,
                UserId = userId,
                ProctorType = proctoringSchedule.ProctorType,
                SlotReferenceId = proctoringSchedule.SlotReferenceId,
                Count = proctoringSchedule.Count,
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
            checker.ProctorType = proctoringSchedule.ProctorType ?? checker.ProctorType;
            checker.SlotReferenceId = proctoringSchedule.SlotReferenceId ?? checker.SlotReferenceId;
            checker.Count = proctoringSchedule.Count;
            this._context.ProctoringSchedules.Update(checker);
            await this._context.SaveChangesAsync();
            return "success";
        }
        
        public async Task UpdateProctoring(ProctoringSchedule proctoringSchedule)
        {
            _context.Update(proctoringSchedule);
            await this._context.SaveChangesAsync();
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
        public async Task CountProctoringAsync(string id)
        {
            var proctoring = await _context.ProctoringSchedules.FindAsync(id);

            if (proctoring != null && proctoring.Count > 0)
            {
                proctoring.Count--; // Giảm Count đi 1
                await _context.SaveChangesAsync(); // Lưu thay đổi vào database

                if(proctoring.Count == 0)
                {
                    proctoring.Status = false;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateProctoringStatusAsync(string id)
        {
            var proctoring = await _context.ProctoringSchedules.FindAsync(id);

            if (proctoring != null && proctoring.Count > 0)
            {
                proctoring.Status = false;
                await _context.SaveChangesAsync(); // Lưu thay đổi vào database
            }
        }

    }
}