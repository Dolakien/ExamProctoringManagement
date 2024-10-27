using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    public class FormSlotController : BaseApiController
    {
        private readonly IFormSlotService _formSlotService;

        public FormSlotController(IFormSlotService formSlotService)
        {
            _formSlotService = formSlotService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormSlot>> GetFormSlot(string id)
        {
            var formSlot = await _formSlotService.GetFormSlotByIdAsync(id);
            if (formSlot == null)
            {
                return NotFound();
            }
            return formSlot;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormSlot>>> GetAllFormSlots()
        {
            var formSlots = await _formSlotService.GetAllFormSlotsAsync();
            return Ok(formSlots);
        }

        [HttpPost]
        public async Task<ActionResult<FormSlot>> CreateFormSlot([FromBody] FormSlot formSlot)
        {
            var createdFormSlot = await _formSlotService.CreateFormSlotAsync(formSlot);
            return CreatedAtAction(nameof(GetFormSlot), new { id = createdFormSlot.FormSlotId}, createdFormSlot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFormSlot(string id, [FromBody] FormSlot formSlot)
        {
            if (id != formSlot.FormSlotId)
            {
                return BadRequest();
            }

            await _formSlotService.UpdateFormSlotAsync(formSlot);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormSlot(string id)
        {
            await _formSlotService.DeleteFormSlotAsync(id);
            return NoContent();
        }
    }
}
