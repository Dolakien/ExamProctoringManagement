using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IReportService
    {
        Task<Report> GetReportByIdAsync(string id);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> CreateReportAsync(ReportCreateDto reportCreateDto);
        Task<Report> UpdateReportAsync(ReportUpdateDto reportUpdateDto);
        Task DeleteReportAsync(string id);
        Task<IEnumerable<Report>> GetReportsByUserIdAsync(string userId);
        Task<IEnumerable<Report>> GetReportsByIsPaidAsync(bool p);
        Task<IEnumerable<Report>> GetReportsByMonthAsync(int month, int year);
    }
}
