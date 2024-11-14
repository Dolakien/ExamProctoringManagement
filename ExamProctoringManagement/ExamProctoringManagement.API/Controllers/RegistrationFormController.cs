using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.Service.Usecases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

    public class RegistrationFormController : BaseApiController
    {
        private readonly IRegistrationFormService _RegistrationFormService;
        private readonly ISlotService _SlotService;
        private readonly IProctoringScheduleService _ProctoringScheduleService;
        private readonly ISlotReferenceService _SlotReferenceService;

        public RegistrationFormController(IRegistrationFormService RegistrationFormService, ISlotService SlotService, IProctoringScheduleService proctoringScheduleService, ISlotReferenceService slotReferenceService)
        {
            _RegistrationFormService = RegistrationFormService;
            _SlotService = SlotService;
            _ProctoringScheduleService = proctoringScheduleService;
            _SlotReferenceService = slotReferenceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationForm>> GetRegistrationForm(string id)
        {
            var RegistrationForm = await _RegistrationFormService.GetRegistrationFormByIdAsync(id);
            if (RegistrationForm == null)
            {
                return NotFound();
            }
            return RegistrationForm;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationForm>>> GetAllRegistrationForms()
        {
            var RegistrationForms = await _RegistrationFormService.GetAllRegistrationFormsAsync();
            return Ok(RegistrationForms);
        }

        [HttpPost("create")]
        public async Task<ActionResult<GetRegisFormWithSlotsDto>> CreateRegistrationForm([FromBody] CreateRegistrationFormDto createRegistrationFormDto)
        {
            var createdRegistrationForm = await _RegistrationFormService.CreateRegistrationFormAsync(createRegistrationFormDto);
            if (createdRegistrationForm != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_CREATE_CODE,
                     Const.SUCCESS_CREATE_MSG,
                     createdRegistrationForm
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_CREATE_MSG));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRegistrationForm([FromBody] RegisFormUpdateDto RegistrationForm)
        {
            var response = await _RegistrationFormService.UpdateRegistrationFormAsync(RegistrationForm);
            if (response != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_UPDATE_CODE,
                     Const.SUCCESS_UPDATE_MSG,
                     "Registration Form is Updated successfully"
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRegistrationForm(string id)
        {
            await _RegistrationFormService.DeleteRegistrationFormAsync(id);
            return Ok();
        }

        [HttpGet("slots")]
        public async Task<ActionResult<GetRegisFormWithSlotsDto>> GetRegisFormWithSlots(string formId)
        {
            if(formId == null)
            {
                return BadRequest();
            }

            var RegistrationForm = await _RegistrationFormService.GetRegisFormWithSlotsAsync(formId);
            if (RegistrationForm == null)
            {
                return NotFound();
            }
            return RegistrationForm;
        }
    }
}
