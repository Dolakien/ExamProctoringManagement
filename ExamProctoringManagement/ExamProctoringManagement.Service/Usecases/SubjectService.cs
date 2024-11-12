using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
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

        public async Task<string> CreateSubjectAsync(SubjectDto Subject)
            => await this._SubjectRepository.CreateAsync(Subject);
         

        public async Task<string> UpdateSubjectAsync(SubjectDto Subject)
            => await this._SubjectRepository.UpdateAsync(Subject);
        

        public async Task DeleteSubjectAsync(string id)
        {
            await _SubjectRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByExamIdAsync(string examId)
        {
            var subjects = await _SubjectRepository.GetAllAsync();
            var list = new List<Subject>();
            foreach (var subject in subjects)
            {
                if (subject.ExamId == examId)
                {
                    list.Add(subject);
                }
            }
            return list;
        }
    }
}
