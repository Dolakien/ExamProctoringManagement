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

        public ReportService(IReportRepository ReportRepository)
        {
            _ReportRepository = ReportRepository;
        }

        public async Task<Report> GetReportByIdAsync(string id)
        {
            return await _ReportRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _ReportRepository.GetAllAsync();
        }

        public async Task<Report> CreateReportAsync(Report Report)
        {
            await _ReportRepository.CreateAsync(Report);
            return Report;
        }

        public async Task UpdateReportAsync(Report Report)
        {
            await _ReportRepository.UpdateAsync(Report);
        }

        public async Task DeleteReportAsync(string id)
        {
            await _ReportRepository.DeleteAsync(id);
        }
    }

}
