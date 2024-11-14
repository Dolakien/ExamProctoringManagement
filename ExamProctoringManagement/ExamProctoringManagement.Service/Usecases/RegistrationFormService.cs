using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using ExamProctoringManagement.Service.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ExamProctoringManagement.Service.Usecases
{
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRegistrationFormRepository _RegistrationFormRepository;
        private readonly IFormSlotRepository _FormSlotRepository;
        private readonly ISlotRepository _SlotRepository;
        private readonly ISlotReferenceService _SlotReferenceService;
        private readonly IProctoringScheduleService _ProctoringScheduleService;
        private readonly IUserService _UserService;
        private readonly SmtpSettings _smtpSetting;

        public RegistrationFormService(IRegistrationFormRepository RegistrationFormRepository, IFormSlotRepository formSlotRepository, ISlotRepository slotRepository, ISlotReferenceService slotReferenceService, IProctoringScheduleService proctoringScheduleService, IOptions<SmtpSettings> smtpSetting, IUserService userService)
        {
            _RegistrationFormRepository = RegistrationFormRepository;
            _FormSlotRepository = formSlotRepository;
            _SlotRepository = slotRepository;
            _SlotReferenceService = slotReferenceService;
            _ProctoringScheduleService = proctoringScheduleService;
            _smtpSetting = smtpSetting.Value;
            _UserService = userService;
        }

        public async Task<RegistrationForm> GetRegistrationFormByIdAsync(string id)
        {
            return await _RegistrationFormRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllRegistrationFormsAsync()
        {
            return await _RegistrationFormRepository.GetAllAsync();
        }

        public async Task<GetRegisFormWithSlotsDto> CreateRegistrationFormAsync(CreateRegistrationFormDto createRegistrationFormDto, string userId)
        {

            var registrations = await _RegistrationFormRepository.GetAllAsync();

            foreach (var existingForm in registrations)
            {
                if (existingForm.UserId == userId && existingForm.ScheduleID == createRegistrationFormDto.ProctoringID && existingForm.Status == true)
                {
                    throw new Exception("Bạn đã đăng ký cho lịch trình này và đã được duyệt!");
                }
                else if (existingForm.UserId == userId && existingForm.ScheduleID == createRegistrationFormDto.ProctoringID && existingForm.Status == false)
                {
                    throw new Exception("Bạn đã đăng ký cho lịch trình này. Hãy chờ Admin duyệt.");
                }
            }
            // Bước 1: Tạo đối tượng RegistrationForm mới
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.FormId = "RegisForm" + Guid.NewGuid().ToString().Substring(0, 4);
            registrationForm.UserId = userId;
            registrationForm.CreateDate = DateTime.Now;
            registrationForm.Status = false;
            registrationForm.ScheduleID = createRegistrationFormDto.ProctoringID;

            await _RegistrationFormRepository.CreateAsync(registrationForm);

            var count = await _ProctoringScheduleService.GetProctoringScheduleByIdAsync(createRegistrationFormDto.ProctoringID);
            var countProctoring = count.Count;
            if (countProctoring > 0)
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
                Status = false
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

        public async Task<List<RegistrationFormUserDTO>> GetAllByUserIdAsync(string userId)
        {
            var RegistrationForm = await _RegistrationFormRepository.GetByUserIdAsync(userId);
            List<RegistrationFormUserDTO> RegistrationFormUserDTOs = new List<RegistrationFormUserDTO>();

            // Lặp qua từng ProctoringSchedule
            foreach (var proctoring in RegistrationForm)
            {
                // Lấy thông tin ProctoringSchedule theo proctoringId
                var proctoringDetail = await _ProctoringScheduleService.GetProctoringScheduleByIdAsync(proctoring.ScheduleID);

                // Lấy thông tin SlotReference từ SlotReferenceRepository
                var slotRefer = await _SlotReferenceService.GetSlotReferenceByIdAsync(proctoringDetail.SlotReferenceId);

                // Lấy thông tin Slot từ SlotRepository
                var slot = await _SlotRepository.GetByIdAsync(slotRefer.SlotId);

                var registration = await _RegistrationFormRepository.GetByIdAsync(proctoring.FormId);

                // Tạo đối tượng ProctoringSlotDTO và thêm vào danh sách
                RegistrationFormUserDTO dto = new RegistrationFormUserDTO()
                {
                    FormId = registration.FormId,
                    UserId = registration.UserId,
                    CreateDate = registration.CreateDate,
                    Status = registration.Status,
                    ScheduleID = registration.ScheduleID,
                    ProctoringType = proctoringDetail.ProctorType,
                    Date = slot.Date,
                    StartDate = slot.Start,
                    EndDate = slot.End,
                };

                RegistrationFormUserDTOs.Add(dto);
            }
            return RegistrationFormUserDTOs;
        }

        public async Task<string> SwapProctoringAsync(SwapProctoring swapProctoring)
        {
            var proctoring = await _ProctoringScheduleService.GetProctoringScheduleByIdAsync(swapProctoring.proctoringId);
           
            // Lấy thông tin SlotReference từ SlotReferenceRepository
            var slotRefer = await _SlotReferenceService.GetSlotReferenceByIdAsync(proctoring.SlotReferenceId);

            // Lấy thông tin Slot từ SlotRepository
            var slot = await _SlotRepository.GetByIdAsync(slotRefer.SlotId);

            if (slot?.Date == null)
            {
                throw new Exception("Slot date is invalid.");
            }

            // Lấy thời gian hiện tại
            DateTime currentDate = DateTime.Now;

            // Kiểm tra nếu ngày hiện tại nằm trong khoảng 3 ngày trước `slot.Date`
            DateTime dateThreshold = slot.Date.Value.AddDays(-7);
            if (currentDate >= dateThreshold && currentDate < slot.Date.Value)
            {
                throw new InvalidOperationException("Cannot swap proctoring within 7 days before the scheduled date.");
            }
            else
            {
                var registrationForm = await _RegistrationFormRepository.GetByIdAsync(swapProctoring.formId);
                string preSchedule = registrationForm.ScheduleID;
                await _RegistrationFormRepository.SwapProctoringAsync(swapProctoring);
                var users = await _UserService.GetAllUsersAsync();
                foreach (var user in users)
                {
                    if (user.RoleId == 1)
                    {
                        await SendSwapRegistrationRequestEmail(user.Email, registrationForm.UserId, registrationForm.FormId, preSchedule, swapProctoring.proctoringId);
                    }
                }

                return "Swap Schedule SuccessFull!";
            }
        }

        public async Task<bool> SendSwapRegistrationRequestEmail(string email, string userId, string registrationFormId, string pre_proctoringId, string after_proctoringId)
        {
            {
                var user = await _UserService.GetUserByEmail(email);
                var user1 = await _UserService.GetUserById(userId);
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Exam Proctoring Management System", _smtpSetting.Username));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "Swap Registration Form Request from User Id: " + userId + "User Email: " + user1.Email;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
                <p>Dear Admin: {user.UserName},</p>
                <p>You have received a request swap Registration Form from User: {user1.UserName}. Request is: Swap ProctoringSchedule: {pre_proctoringId} to {after_proctoringId} of Registration Form: {registrationFormId}</p>
                <p>Please check the request carefully and approve it!!!</p>
                <p>Do not request this email.</p>
                <p>Thank you, Admin</p>
            ";

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    try
                    {
                        client.Connect(_smtpSetting.SmtpServer, _smtpSetting.Port, _smtpSetting.UseSsl);
                        client.Authenticate(_smtpSetting.Username, _smtpSetting.Password);
                        await client.SendAsync(message);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email: {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        await client.DisconnectAsync(true);
                    }
                }
            }
        }
    }
}
