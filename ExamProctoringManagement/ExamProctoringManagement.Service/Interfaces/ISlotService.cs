﻿using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface ISlotService
    {
        Task<Slot> GetSlotByIdAsync(string id);
        Task<IEnumerable<Slot>> GetAllSlotsAsync();
        Task<Slot> CreateSlotAsync(Slot Slot);
        Task UpdateSlotAsync(Slot Slot);
        Task DeleteSlotAsync(string id);
    }
}
