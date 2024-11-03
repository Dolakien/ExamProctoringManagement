using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface ISubjectService
    {
        Task<Subject> GetSubjectByIdAsync(string id);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> CreateSubjectAsync(Subject Subject);
        Task UpdateSubjectAsync(Subject Subject);
        Task DeleteSubjectAsync(string id);
        Task<IEnumerable<Subject>> GetSubjectsByExamIdAsync(string examId);
    }
}
