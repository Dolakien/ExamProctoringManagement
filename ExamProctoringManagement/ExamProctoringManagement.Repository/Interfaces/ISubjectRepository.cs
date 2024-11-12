using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface ISubjectRepository
    {
        Task<Subject> GetByIdAsync(string id);
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<string> CreateAsync(SubjectDto Subject);
        Task<string> UpdateAsync(SubjectDto Subject);
        Task DeleteAsync(string id);
    }
}
