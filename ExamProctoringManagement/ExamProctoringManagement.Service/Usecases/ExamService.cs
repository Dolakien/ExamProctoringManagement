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
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<Exam> GetExamByIdAsync(string id)
        {
            return await _examRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {
            return await _examRepository.GetAllAsync();
        }

        public async Task<string> CreateExamAsync(ExamDTO exam)
            => await this._examRepository.CreateAsync(exam);
         

        public async Task<string> UpdateExamAsync(ExamDTO exam)
            => await this._examRepository.UpdateAsync(exam);
        

        public async Task DeleteExamAsync(string id)
        {
            await _examRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Exam>> GetExamsBySemesterIdAsync(string semesterId)
        {
            var exams = await _examRepository.GetAllAsync();
            var list = new List<Exam>();
            foreach (var exam in exams)
            {
                if (exam.SemesterId == semesterId)
                {
                    list.Add(exam);
                }
            }
            return list;
        }
    }
}
