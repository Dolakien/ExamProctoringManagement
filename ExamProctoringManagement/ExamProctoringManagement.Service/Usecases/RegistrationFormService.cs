using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request;
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
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRegistrationFormRepository _RegistrationFormRepository;
        private readonly IFormSlotRepository _FormSlotRepository;
        private readonly ISlotRepository _SlotRepository;
        private readonly ISlotReferenceService _SlotReferenceService;
        private readonly IProctoringScheduleService _ProctoringScheduleService;
        public RegistrationFormService(IRegistrationFormRepository RegistrationFormRepository, IFormSlotRepository formSlotRepository, ISlotRepository slotRepository, ISlotReferenceService slotReferenceService, IProctoringScheduleService proctoringScheduleService)
        {
            _RegistrationFormRepository = RegistrationFormRepository;
            _FormSlotRepository = formSlotRepository;
            _SlotRepository = slotRepository;
            _SlotReferenceService = slotReferenceService;
            _ProctoringScheduleService = proctoringScheduleService;
        }

        public async Task<RegistrationForm> GetRegistrationFormByIdAsync(string id)
        {
            return await _RegistrationFormRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllRegistrationFormsAsync()
        {
            return await _RegistrationFormRepository.GetAllAsync();
        }

        public async Task<GetRegisFormWithSlotsDto> CreateRegistrationFormAsync(CreateRegistrationFormDto createRegistrationFormDto)
        {
            // Bước 1: Tạo đối tượng RegistrationForm mới
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.FormId = createRegistrationFormDto.FormId;
            registrationForm.UserId = createRegistrationFormDto.UserId;
            registrationForm.CreateDate = DateTime.Now;
            registrationForm.Status = false;
            await _RegistrationFormRepository.CreateAsync(registrationForm);

            var count = await _ProctoringScheduleService.GetProctoringScheduleByIdAsync(createRegistrationFormDto.ProctoringID);
            if (count.Count > 0)
            {
                await _ProctoringScheduleService.CountProctoringAsync(createRegistrationFormDto.ProctoringID);
            }
            else {
                throw new Exception("Hết Slot Đăng Kí!");
            }
            var slotRefer = await _SlotReferenceService.GetSlotReferenceByIdAsync(count.SlotReferenceId);

            FormSlot formSlot = new FormSlot
                {
                    FormSlotId = "FormSlot" + Guid.NewGuid().ToString().Substring(0, 5),
                    FormId = registrationForm.FormId,
                    SlotId = slotRefer.SlotId,
                    Status = true
                };

                // Lưu FormSlot vào cơ sở dữ liệu
                await _FormSlotRepository.CreateAsync(formSlot);
            

            // Bước 3: Tạo đối tượng GetRegisFormWithSlotsDto để trả về
            GetRegisFormWithSlotsDto dto = new GetRegisFormWithSlotsDto
            {
                FormId = registrationForm.FormId,
                UserId = registrationForm.UserId,
                CreateDate = DateTime.Now,
                Status = true
            };

            return dto;
        }


        public async Task<RegistrationForm> UpdateRegistrationFormAsync(RegisFormUpdateDto RegistrationForm)
        {
            return await _RegistrationFormRepository.UpdateAsync(RegistrationForm);
        }

        public async Task DeleteRegistrationFormAsync(string id)
        {
            await _RegistrationFormRepository.DeleteAsync(id);
        }

        public async Task<GetRegisFormWithSlotsDto> GetRegisFormWithSlotsAsync(string formId)
        {
            var regisForm = await _RegistrationFormRepository.GetByIdAsync(formId);
            var dto = new GetRegisFormWithSlotsDto();   
            dto.FormId = regisForm.FormId;
            dto.UserId = regisForm.UserId;
            dto.CreateDate = (DateTime)regisForm.CreateDate;
            dto.Status = (bool)regisForm.Status;

            var formSlots = await _FormSlotRepository.GetFormSlotsByRegisFormAsync(regisForm);
            var slots = new List<Slot>();
            foreach (var formSlot in formSlots)
            {
                var slot = await _SlotRepository.GetByIdAsync(formSlot.SlotId);
                slots.Add(slot);
            }
            dto.Slots = slots;

            return dto;
        }
    }
}
