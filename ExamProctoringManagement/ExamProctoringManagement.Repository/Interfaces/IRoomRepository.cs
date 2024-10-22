using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(string id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task CreateAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(string id);
    }
}
