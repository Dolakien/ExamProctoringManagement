using ExamProctoringManagement.Contract.DTOs;
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
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _SemesterRepository;

        public SemesterService(ISemesterRepository SemesterRepository)
        {
            _SemesterRepository = SemesterRepository;
        }

        public async Task<Semester> GetSemesterByIdAsync(string id)
        {
            return await _SemesterRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Semester>> GetAllSemestersAsync()
        {
            return await _SemesterRepository.GetAllAsync();
        }

        public async Task<SemesterCreateDto> CreateSemesterAsync(SemesterCreateDto Semester)
        {
            await _SemesterRepository.CreateAsync(Semester);
            return Semester;
        }

        public async Task<Semester> UpdateSemesterAsync(SemesterUpdateDto Semester)
        {
            return await _SemesterRepository.UpdateAsync(Semester);
        }

        public async Task DeleteSemesterAsync(string id)
        {
            await _SemesterRepository.DeleteAsync(id);
        }
    }

}
