﻿using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _SlotRepository;
        private readonly IExamRepository _ExamRepository;
        private readonly ISlotReferenceRepository _SlotReferenceRepository;
        private readonly IProctoringScheduleRepository _ProctoringScheduleRepository;

        public SlotService(ISlotRepository SlotRepository, IExamRepository examRepository,
            ISlotReferenceRepository slotReferenceRepository,
            IProctoringScheduleRepository proctoringScheduleRepository)
        {
            _SlotRepository = SlotRepository;
            _ExamRepository = examRepository;
            _SlotReferenceRepository = slotReferenceRepository;
            _ProctoringScheduleRepository = proctoringScheduleRepository;
        }

        public async Task<Slot> GetSlotByIdAsync(string id)
        {
            return await _SlotRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Slot>> GetAllSlotsAsync()
        {
            return await _SlotRepository.GetAllAsync();
        }

        public async Task<Slot> CreateSlotAsync(SlotDTO slotDTO)
        {
            // Chuyển đổi chuỗi `Start` và `End` thành `TimeOnly`
            if (!TimeOnly.TryParse(slotDTO.Start, out TimeOnly startTime))
            {
                throw new ArgumentException("Thời gian bắt đầu không hợp lệ", nameof(slotDTO.Start));
            }

            if (!TimeOnly.TryParse(slotDTO.End, out TimeOnly endTime))
            {
                throw new ArgumentException("Thời gian kết thúc không hợp lệ", nameof(slotDTO.End));
            }

            // Tạo đối tượng Slot mới
            Slot slot = new Slot
            {
                SlotId = "Slot" + Guid.NewGuid().ToString().Substring(0, 5),
                Date = slotDTO.Date,
                Start = startTime,
                End = endTime,
                Status = true,
                ExamId = slotDTO.ExamId
            };

            // Lưu vào kho dữ liệu
            await _SlotRepository.CreateAsync(slot);
            return slot;
        }


        public async Task<string> UpdateSlotAsync(UpdateSlotRequest updateSlot)
        {
            // Chuyển đổi chuỗi `Start` và `End` thành `TimeOnly`
            if (!TimeOnly.TryParse(updateSlot.Start, out TimeOnly startTime))
            {
                throw new ArgumentException("Thời gian bắt đầu không hợp lệ", nameof(updateSlot.Start));
            }

            if (!TimeOnly.TryParse(updateSlot.End, out TimeOnly endTime))
            {
                throw new ArgumentException("Thời gian kết thúc không hợp lệ", nameof(updateSlot.End));
            }

            var slotResponse = await _SlotRepository.GetByIdAsync(updateSlot.SlotId);
            if (slotResponse == null)
            {
                throw new Exception("Not found this Slot!");
            }
            // Tạo đối tượng Slot mới

            slotResponse.SlotId = slotResponse.SlotId;
            slotResponse.Date = updateSlot.Date;
            slotResponse.Start = startTime;
            slotResponse.End = endTime;
            slotResponse.Status = true;
            slotResponse.ExamId = updateSlot.ExamId;
        

            // Lưu vào kho dữ liệu
            await _SlotRepository.UpdateAsync(slotResponse);
            return "Update Successfully!";
        }

        public async Task DeleteSlotAsync(string id)
        {
            await _SlotRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Slot>> GetSlotsByExamIdAsync(string examId)
        {
            return await _SlotRepository.GetSlotsByExamAsync(await _ExamRepository.GetByIdAsync(examId));
        }

        public async Task<IEnumerable<Slot>> GetAvailableSlotsByExamId(string examId)
        {
            var slots = await _SlotRepository.GetSlotsByExamAsync(await _ExamRepository.GetByIdAsync(examId));
            var availableSlots = new List<Slot>();

            foreach (var slot in slots)
            {
                var slotReferences = await _SlotReferenceRepository.GetSlotReferencesBySlotAsync(slot);

                var hasUnscheduledSlotReference = slotReferences.Any(slotRef =>
                    !_ProctoringScheduleRepository.HasProctoringScheduleAsync(slotRef.SlotReferenceId).Result);

                if (hasUnscheduledSlotReference)
                {
                    availableSlots.Add(slot);
                }
            }

            return availableSlots;
        }

        public async Task<SlotCountDto> GetSlotCountAndTotalTime(string userId, string semesterId)
        {
            var schedules = await _ProctoringScheduleRepository.GetByUserIdAndIsFinishedAsync(userId, true);

            var slotReferenceIds = schedules.Select(s => s.SlotReferenceId).ToList();
            var slotReferences = new List<SlotReference>();
            foreach (var slotReferenceId in slotReferenceIds)
            {
                var slotReference = await _SlotReferenceRepository.GetByIdAsync(slotReferenceId);
                slotReferences.Add(slotReference);
            }

            var slotIds = slotReferences.Select(sr => sr.SlotId).ToList();
            var slots = new List<Slot>();
            foreach (var slotId in slotIds)
            {
                var slot = await _SlotRepository.GetByIdAsync(slotId);
                var exam = await _ExamRepository.GetByIdAsync(slot.ExamId);
                if (exam != null && exam.SemesterId == semesterId)
                {
                    slots.Add(slot);
                }
            }

            float totalTime = 0;
            foreach (var slot in slots)
            {
                if (slot.Start.HasValue && slot.End.HasValue)
                {
                    totalTime += (float)(slot.End.Value - slot.Start.Value).TotalHours;
                }
            }

            SlotCountDto slotCountDto = new SlotCountDto();
            slotCountDto.SlotCount = slots.Count();
            slotCountDto.TotalTime = totalTime;
            return slotCountDto;
        }
    }
}
