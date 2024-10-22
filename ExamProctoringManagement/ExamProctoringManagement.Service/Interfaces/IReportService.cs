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
        Task<Report> CreateReportAsync(Report Report);
        Task UpdateReportAsync(Report Report);
        Task DeleteReportAsync(string id);
    }
}
