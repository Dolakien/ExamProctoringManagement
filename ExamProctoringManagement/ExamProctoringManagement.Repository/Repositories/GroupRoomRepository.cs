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
    public class GroupRoomRepository : IGroupRoomRepository
    {
        private readonly GroupRoomDAO _grouproomDAO;

        public GroupRoomRepository(GroupRoomDAO grouproomDAO)
        {
            _grouproomDAO = grouproomDAO;
        }

        public async Task<GroupRoom> GetByIdAsync(string id)
        {
            return await _grouproomDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<GroupRoom>> GetAllAsync()
        {
            return await _grouproomDAO.GetAllAsync();
        }

        public async Task CreateAsync(GroupRoom GroupRoom)
        {
            await _grouproomDAO.CreateAsync(GroupRoom);
        }

        public async Task UpdateAsync(GroupRoom GroupRoom)
        {
            await _grouproomDAO.UpdateAsync(GroupRoom);
        }

        public async Task DeleteAsync(string id)
        {
            await _grouproomDAO.DeleteAsync(id);
        }
    }
}
