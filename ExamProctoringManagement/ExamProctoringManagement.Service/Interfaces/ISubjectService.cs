using ExamProctoringManagement.Contract.DTOs;
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
        Task<string> CreateSubjectAsync(SubjectDto Subject);
        Task<string> UpdateSubjectAsync(SubjectDto Subject);
        Task DeleteSubjectAsync(string id);
        Task<IEnumerable<Subject>> GetSubjectsByExamIdAsync(string examId);
    }
}
