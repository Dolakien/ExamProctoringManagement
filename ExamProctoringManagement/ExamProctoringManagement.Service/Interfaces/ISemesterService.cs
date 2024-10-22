using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface ISemesterService
    {
        Task<Semester> GetSemesterByIdAsync(string id);
        Task<IEnumerable<Semester>> GetAllSemestersAsync();
        Task<Semester> CreateSemesterAsync(Semester Semester);
        Task UpdateSemesterAsync(Semester Semester);
        Task DeleteSemesterAsync(string id);
    }
}
