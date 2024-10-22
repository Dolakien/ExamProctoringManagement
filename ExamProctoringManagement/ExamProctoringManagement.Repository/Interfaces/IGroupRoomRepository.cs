using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IGroupRoomRepository
    {
        Task<GroupRoom> GetByIdAsync(string id);
        Task<IEnumerable<GroupRoom>> GetAllAsync();
        Task CreateAsync(GroupRoom groupRoom);
        Task UpdateAsync(GroupRoom groupRoom);
        Task DeleteAsync(string id);
    }
}
