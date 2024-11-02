using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _ReportRepository;
        private readonly IProctoringScheduleRepository _ProctoringScheduleRepository;
        private readonly ISlotReferenceRepository _SlotReferenceRepository;
        private readonly ISlotRepository _SlotRepository;

        public ReportService(IReportRepository ReportRepository, IProctoringScheduleRepository ProctoringScheduleRepository,
            ISlotReferenceRepository SlotReferenceRepository, ISlotRepository SlotRepository)
        {
            _ReportRepository = ReportRepository;
            _ProctoringScheduleRepository = ProctoringScheduleRepository;
            _SlotReferenceRepository = SlotReferenceRepository;
            _SlotRepository = SlotRepository;
        }

        public async Task<Report> GetReportByIdAsync(string id)
        {
            return await _ReportRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _ReportRepository.GetAllAsync();
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            report.TotalHours = await CalculateTotalHours(report.UserId, report.FromDate, report.ToDate);
            report.TotalAmount = (decimal?)(report.TotalHours * (float?)report.UnitPerHour);
            report.IsPaid = false;

            await _ReportRepository.CreateAsync(report);
            return report;
        }

        public async Task UpdateReportAsync(Report report)
        {
            report.TotalHours = await CalculateTotalHours(report.UserId, report.FromDate, report.ToDate);
            report.TotalAmount = (decimal?)(report.TotalHours * (float?)report.UnitPerHour);

            await _ReportRepository.UpdateAsync(report);
        }

        public async Task DeleteReportAsync(string id)
        {
            await _ReportRepository.DeleteAsync(id);
        }

        private async Task<float?> CalculateTotalHours(string userId, DateTime? fromDate, DateTime? toDate)
        {
            var schedules = await _ProctoringScheduleRepository.GetByUserIdAndIsFinishedAsync(userId, true);

            var slotReferenceIds = schedules.Select(s => s.SlotReferenceId).ToList();
            var slotReferences = new List<SlotReference>();
            foreach (var slotReferenceId in slotReferenceIds)
            {
                var slotReference = await _SlotReferenceRepository.GetByIdAsync(slotReferenceId);
                slotReferences.Add(slotReference);
            }

            var slotIds = slotReferences.Select(sr => sr.SlotId).ToList();
            var slots = new List<Slot>();
            foreach (var slotId in slotIds)
            {
                var slot = await _SlotRepository.GetByIdAsync(slotId);
                slots.Add(slot);
            }

            float? totalHours = 0;
            foreach (var slot in slots)
            {
                if (slot.Date >= fromDate && slot.Date <= toDate)
                {
                    if (slot.Start.HasValue && slot.End.HasValue)
                    {
                        totalHours += (float)(slot.End.Value - slot.Start.Value).TotalHours;
                    }
                }
            }

            return totalHours;
        }

        public async Task<IEnumerable<Report>> GetReportsByUserIdAsync(string userId)
        {
            var reports = await _ReportRepository.GetAllAsync();
            var list = new List<Report>();
            foreach (var report in reports)
            {
                if(report.UserId == userId)
                {
                    list.Add(report);
                }
            }
            return list;
        }

        public async Task<IEnumerable<Report>> GetReportsByIsPaidAsync(bool p)
        {
            var reports = await _ReportRepository.GetAllAsync();
            var list = new List<Report>();
            foreach (var report in reports)
            {
                if (report.IsPaid == p)
                {
                    list.Add(report);
                }
            }
            return list;
        }

        public async Task<IEnumerable<Report>> GetReportsByMonthAsync(int month, int year)
        {
            var reports = await _ReportRepository.GetAllAsync();
            var list = new List<Report>();
            foreach (var report in reports)
            {
                if (report.FromDate.Value.Month == month && report.FromDate.Value.Year == year)
                {
                    list.Add(report);
                }
            }
            return list;
        }
    }
}
