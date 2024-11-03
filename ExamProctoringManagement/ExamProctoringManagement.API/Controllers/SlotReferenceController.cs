using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotReferenceController : ControllerBase
    {
        private readonly ISlotReferenceService _SlotReferenceService;

        public SlotReferenceController(ISlotReferenceService SlotReferenceService)
        {
            _SlotReferenceService = SlotReferenceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SlotReference>> GetSlotReference(string id)
        {
            var SlotReference = await _SlotReferenceService.GetSlotReferenceByIdAsync(id);
            if (SlotReference == null)
            {
                return NotFound();
            }
            return SlotReference;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlotReference>>> GetAllSlotReferences()
        {
            var SlotReferences = await _SlotReferenceService.GetAllSlotReferencesAsync();
            return Ok(SlotReferences);
        }

        [HttpPost]
        public async Task<ActionResult<SlotReference>> CreateSlotReference([FromBody] SlotReference SlotReference)
        {
            if (SlotReference.SlotId == null)
            {
                return BadRequest("SlotId null.");
            }
            if ((SlotReference.RoomId == null && SlotReference.GroupId == null) ||
                (SlotReference.RoomId != null && SlotReference.GroupId != null)) 
            {
                return BadRequest("Only RoomId or GroupId exists.");
            }
            var createdSlotReference = await _SlotReferenceService.CreateSlotReferenceAsync(SlotReference);
            return CreatedAtAction(nameof(GetSlotReference), new { id = createdSlotReference.SlotReferenceId }, createdSlotReference);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlotReference(string id, [FromBody] SlotReference SlotReference)
        {
            if (id != SlotReference.SlotReferenceId)
            {
                return BadRequest();
            }

            await _SlotReferenceService.UpdateSlotReferenceAsync(SlotReference);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlotReference(string id)
        {
            await _SlotReferenceService.DeleteSlotReferenceAsync(id);
            return NoContent();
        }

        [HttpGet("room")]
        public async Task<ActionResult<IEnumerable<SlotReferenceWithRoomDto>>> GetSlotReferencesWithRoom()
        {
            var dto = await _SlotReferenceService.GetSlotReferencesWithRoomAsync();
            return Ok(dto);
        }

        [HttpGet("slot")]
        public async Task<ActionResult<IEnumerable<SlotReferenceWithRoomDto>>> GetSlotReferencesBySlotId(string slotId)
        {
            var slotReferences = await _SlotReferenceService.GetSlotReferencesBySlotIdAsync(slotId);
            return Ok(slotReferences);
        }
    }
}
