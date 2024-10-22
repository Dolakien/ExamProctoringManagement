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
        Task<Exam> CreateExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(string id);
    }
}
