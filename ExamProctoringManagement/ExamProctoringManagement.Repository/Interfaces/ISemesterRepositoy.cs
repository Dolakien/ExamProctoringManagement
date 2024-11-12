using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface ISemesterRepository
    {
        Task<Semester> GetByIdAsync(string id);
        Task<IEnumerable<Semester>> GetAllAsync();
        Task<Semester> CreateAsync(SemesterCreateDto semesterCreateDto);
        Task<Semester> UpdateAsync(SemesterUpdateDto semesterUpdateDto);
        Task DeleteAsync(string id);
    }
}
