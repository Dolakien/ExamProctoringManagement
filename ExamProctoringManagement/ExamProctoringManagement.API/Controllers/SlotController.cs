using Azure;
using ExamProctoringManagement.Contract.DTOs;
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
        public async Task<ActionResult<Slot>> CreateSlot([FromBody] SlotDTO slotDTO)
        {
            var createdSlot = await _SlotService.CreateSlotAsync(slotDTO);
            return CreatedAtAction(nameof(GetSlot), new { id = createdSlot.SlotId }, createdSlot);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlot([FromBody] UpdateSlotRequest slotDTO)
        {
            var response = await _SlotService.UpdateSlotAsync(slotDTO);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(string id)
        {
            await _SlotService.DeleteSlotAsync(id);
            return NoContent();
        }

        [HttpGet("exam")]
        public async Task<ActionResult<IEnumerable<Slot>>> GetSlotsByExamId(string examId)
        {
            var Slots = await _SlotService.GetSlotsByExamIdAsync(examId);
            return Ok(Slots);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Slot>>> GetAvailableSlotsByExamId(string examId)
        {
            var Slots = await _SlotService.GetAvailableSlotsByExamId(examId);
            return Ok(Slots);
        }

        [HttpGet("slotCount")]
        public async Task<ActionResult<SlotCountDto>> GetCurrentSlotCountAndTotalTime(string userId, string semesterId)
        {
            var slotCount = await _SlotService.GetSlotCountAndTotalTime(userId, semesterId);
            return Ok(slotCount);
        }
    }
}
