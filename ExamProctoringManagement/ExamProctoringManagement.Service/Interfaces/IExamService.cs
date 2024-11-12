using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IExamService
    {
        Task<Exam> GetExamByIdAsync(string id);
        Task<IEnumerable<Exam>> GetAllExamsAsync();
        Task<string> CreateExamAsync(ExamDTO exam);
        Task<string> UpdateExamAsync(ExamDTO exam);
        Task DeleteExamAsync(string id);
        Task<IEnumerable<Exam>> GetExamsBySemesterIdAsync(string semesterId);
    }
}
