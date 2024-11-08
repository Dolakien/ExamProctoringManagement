using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

    public class RegistrationFormController : BaseApiController
    {
        private readonly IRegistrationFormService _RegistrationFormService;
        private readonly ISlotService _SlotService;

        public RegistrationFormController(IRegistrationFormService RegistrationFormService, ISlotService SlotService)
        {
            _RegistrationFormService = RegistrationFormService;
            _SlotService = SlotService;
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

        [HttpPost]
        public async Task<ActionResult<GetRegisFormWithSlotsDto>> CreateRegistrationForm([FromBody] CreateRegistrationFormDto createRegistrationFormDto)
        {
            if (createRegistrationFormDto.FormSlotIds.Count() != createRegistrationFormDto.SlotIds.Count()) 
            { 
                return BadRequest();
            }

            var slots = await _SlotService.GetAvailableSlotsByExamId(createRegistrationFormDto.ExamId);
            foreach (string slotId in createRegistrationFormDto.SlotIds)
            {
                if (!slots.Any(s => s.SlotId == slotId))
                {
                    return BadRequest("Slot đã chọn không có sẵn");
                }
            }

            var createdRegistrationForm = await _RegistrationFormService.CreateRegistrationFormAsync(createRegistrationFormDto);
            return CreatedAtAction(nameof(GetRegistrationForm), new { id = createdRegistrationForm.FormId }, createdRegistrationForm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistrationForm(string id, [FromBody] RegistrationForm RegistrationForm)
        {
            if (id != RegistrationForm.FormId)
            {
                return BadRequest();
            }

            await _RegistrationFormService.UpdateRegistrationFormAsync(RegistrationForm);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationForm(string id)
        {
            await _RegistrationFormService.DeleteRegistrationFormAsync(id);
            return NoContent();
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
