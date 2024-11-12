using AutoMapper;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Exceptions;
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
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ReportRepository(ReportDAO ReportDAO, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ReportDAO = ReportDAO;
            _uow = unitOfWork;
            _mapper = mapper;
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

        public async Task<Report> UpdateAsync(Report Report)
        {
            await _uow.ReportDAO.UpdateAsync(Report);
            return Report;
        }

        public async Task DeleteAsync(string id)
        {
            await _ReportDAO.DeleteAsync(id);
        }
    }
}
