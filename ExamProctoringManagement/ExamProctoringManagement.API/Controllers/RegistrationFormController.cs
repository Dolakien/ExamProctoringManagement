using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationFormController : BaseApiController
    {
        private readonly IRegistrationFormService _RegistrationFormService;

        public RegistrationFormController(IRegistrationFormService RegistrationFormService)
        {
            _RegistrationFormService = RegistrationFormService;
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
        public async Task<ActionResult<RegistrationForm>> CreateRegistrationForm(RegistrationForm RegistrationForm)
        {
            var createdRegistrationForm = await _RegistrationFormService.CreateRegistrationFormAsync(RegistrationForm);
            return CreatedAtAction(nameof(GetRegistrationForm), new { id = createdRegistrationForm.FormId }, createdRegistrationForm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistrationForm(string id, RegistrationForm RegistrationForm)
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
    }
}
