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
    public class SemesterRepository : ISemesterRepository
    {
        private readonly SemesterDAO _SemesterDAO;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SemesterRepository(SemesterDAO SemesterDAO, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _SemesterDAO = SemesterDAO;
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Semester> GetByIdAsync(string id)
        {
            return await _SemesterDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Semester>> GetAllAsync()
        {
            return await _SemesterDAO.GetAllAsync();
        }

        public async Task<Semester> CreateAsync(SemesterCreateDto semesterCreateDto)
        {
            var existSemester = await _uow.SemesterDAO.GetByIdAsync(semesterCreateDto.SemesterId);
            if (existSemester != null)
            {
                throw new BadRequestException("Semester existed");
            }

            Semester semester = new Semester();
            semester.SemesterId = semesterCreateDto.SemesterId;
            semester.SemesterName = semesterCreateDto.SemesterName;
            semester.FromDate = semesterCreateDto.FromDate;
            semester.ToDate = semesterCreateDto.ToDate;
            semester.Status = semesterCreateDto.Status;
            await _uow.SemesterDAO.CreateAsync(semester);
            await _uow.SaveChangesAsync();
            return semester;
        }

        public async Task<Semester> UpdateAsync(SemesterUpdateDto semesterUpdateDto)
        {
            var existedSemester = await _uow.SemesterDAO.GetByIdAsync(semesterUpdateDto.SemesterId);
            if (existedSemester == null)
            {
                throw new SemesterNotFoundException(semesterUpdateDto.SemesterId);
            }
            _mapper.Map(semesterUpdateDto, existedSemester);
            await _uow.SemesterDAO.UpdateAsync(existedSemester);

            return existedSemester;
        }

        public async Task DeleteAsync(string id)
        {
            await _SemesterDAO.DeleteAsync(id);
        }
    }
}
