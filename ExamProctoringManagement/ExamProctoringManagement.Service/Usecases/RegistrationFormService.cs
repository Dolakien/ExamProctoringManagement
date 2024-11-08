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

        public RegistrationFormService(IRegistrationFormRepository RegistrationFormRepository, IFormSlotRepository formSlotRepository, ISlotRepository slotRepository)
        {
            _RegistrationFormRepository = RegistrationFormRepository;
            _FormSlotRepository = formSlotRepository;
            _SlotRepository = slotRepository;
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
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.FormId = createRegistrationFormDto.FormId; 
            registrationForm.UserId = createRegistrationFormDto.UserId;
            registrationForm.CreateDate = DateTime.Now;
            registrationForm.Status = true;
            await _RegistrationFormRepository.CreateAsync(registrationForm);

            for (int i = 0; i < createRegistrationFormDto.FormSlotIds.Count; i++)
            {
                FormSlot formSlot = new FormSlot
                {
                    FormSlotId = createRegistrationFormDto.FormSlotIds[i],
                    FormId = createRegistrationFormDto.FormId,
                    SlotId = createRegistrationFormDto.SlotIds[i],
                    Status = true
                };
                await _FormSlotRepository.CreateAsync(formSlot);
            }

            GetRegisFormWithSlotsDto dto = new GetRegisFormWithSlotsDto();
            dto.FormId = createRegistrationFormDto.FormId;
            dto.UserId = createRegistrationFormDto.UserId;
            dto.CreateDate = DateTime.Now;
            dto.Status = true;

            var slots = new List<Slot>();             
            foreach (var slotId in createRegistrationFormDto.SlotIds)
            {
                Slot slot = await _SlotRepository.GetByIdAsync(slotId);
                slots.Add(slot);
            }
            dto.Slots = slots;

            return dto;
        }

        public async Task UpdateRegistrationFormAsync(RegistrationForm RegistrationForm)
        {
            await _RegistrationFormRepository.UpdateAsync(RegistrationForm);
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
