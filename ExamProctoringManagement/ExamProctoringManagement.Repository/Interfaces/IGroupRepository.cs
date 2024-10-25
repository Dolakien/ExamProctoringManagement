using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> GetByIdAsync(string id);
        Task<IEnumerable<Group>> GetAllAsync();
        Task CreateAsync(Group group);
        Task UpdateAsync(Group group);
        Task DeleteAsync(string id);
    }
}
