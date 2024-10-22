using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportDAO _ReportDAO;

        public ReportRepository(ReportDAO ReportDAO)
        {
            _ReportDAO = ReportDAO;
        }

        public async Task<Report> GetByIdAsync(string id)
        {
            return await _ReportDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _ReportDAO.GetAllAsync();
        }

        public async Task CreateAsync(Report Report)
        {
            await _ReportDAO.CreateAsync(Report);
        }

        public async Task UpdateAsync(Report Report)
        {
            await _ReportDAO.UpdateAsync(Report);
        }

        public async Task DeleteAsync(string id)
        {
            await _ReportDAO.DeleteAsync(id);
        }
    }
}
