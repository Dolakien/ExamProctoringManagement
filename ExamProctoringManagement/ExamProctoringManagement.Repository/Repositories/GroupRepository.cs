using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly GroupDAO _groupDAO;

        public GroupRepository(GroupDAO groupDAO)
        {
            _groupDAO = groupDAO;
        }

        public async Task<Group> GetByIdAsync(string id)
        {
            return await _groupDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _groupDAO.GetAllAsync();
        }

        public async Task CreateAsync(Group group)
        {
            await _groupDAO.CreateAsync(group);
        }

        public async Task UpdateAsync(Group group)
        {
            await _groupDAO.UpdateAsync(group);
        }

        public async Task DeleteAsync(string id)
        {
            await _groupDAO.DeleteAsync(id);
        }
    }
}
