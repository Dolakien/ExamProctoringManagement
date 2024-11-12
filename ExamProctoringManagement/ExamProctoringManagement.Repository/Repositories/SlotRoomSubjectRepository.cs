using ExamProctoringManagement.Contract.DTOs;
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
    public class SlotRoomSubjectRepository : ISlotRoomSubjectRepository
    {
        private readonly SlotRoomSubjectDAO _SlotRoomSubjectDAO;

        public SlotRoomSubjectRepository(SlotRoomSubjectDAO SlotRoomSubjectDAO)
        {
            _SlotRoomSubjectDAO = SlotRoomSubjectDAO;
        }

        public async Task<SlotRoomSubject> GetByIdAsync(string id)
        {
            return await _SlotRoomSubjectDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SlotRoomSubject>> GetAllAsync()
        {
            return await _SlotRoomSubjectDAO.GetAllAsync();
        }

        public async Task<string> CreateAsync(SlotRoomSubjectDTO SlotRoomSubject)
            => await this._SlotRoomSubjectDAO.CreateAsync(SlotRoomSubject);
        

        public async Task<string> UpdateAsync(SlotRoomSubjectDTO SlotRoomSubject)
            => await this._SlotRoomSubjectDAO.UpdateAsync(SlotRoomSubject);
        

        public async Task DeleteAsync(string id)
        {
            await _SlotRoomSubjectDAO.DeleteAsync(id);
        }
    }
}
