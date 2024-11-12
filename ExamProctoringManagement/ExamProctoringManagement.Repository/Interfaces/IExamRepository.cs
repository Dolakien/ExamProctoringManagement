using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IExamRepository
    {
        Task<Exam> GetByIdAsync(string id);
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<string> CreateAsync(ExamDTO exam);
        Task<string> UpdateAsync(ExamDTO exam);
        Task DeleteAsync(string id);
    }
}
