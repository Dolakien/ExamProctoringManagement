using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _SlotService;

        public SlotController(ISlotService SlotService)
        {
            _SlotService = SlotService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Slot>> GetSlot(string id)
        {
            var Slot = await _SlotService.GetSlotByIdAsync(id);
            if (Slot == null)
            {
                return NotFound();
            }
            return Slot;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slot>>> GetAllSlots()
        {
            var Slots = await _SlotService.GetAllSlotsAsync();
            return Ok(Slots);
        }

        [HttpPost]
        public async Task<ActionResult<Slot>> CreateSlot([FromBody] Slot Slot)
        {
            var createdSlot = await _SlotService.CreateSlotAsync(Slot);
            return CreatedAtAction(nameof(GetSlot), new { id = createdSlot.SlotId }, createdSlot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot(string id, [FromBody] Slot Slot)
        {
            if (id != Slot.SlotId)
            {
                return BadRequest();
            }

            await _SlotService.UpdateSlotAsync(Slot);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(string id)
        {
            await _SlotService.DeleteSlotAsync(id);
            return NoContent();
        }
    }
}
