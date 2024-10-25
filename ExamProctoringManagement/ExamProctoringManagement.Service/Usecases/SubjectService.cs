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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _SubjectRepository;

        public SubjectService(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }

        public async Task<Subject> GetSubjectByIdAsync(string id)
        {
            return await _SubjectRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _SubjectRepository.GetAllAsync();
        }

        public async Task<Subject> CreateSubjectAsync(Subject Subject)
        {
            await _SubjectRepository.CreateAsync(Subject);
            return Subject;
        }

        public async Task UpdateSubjectAsync(Subject Subject)
        {
            await _SubjectRepository.UpdateAsync(Subject);
        }

        public async Task DeleteSubjectAsync(string id)
        {
            await _SubjectRepository.DeleteAsync(id);
        }
    }

}
