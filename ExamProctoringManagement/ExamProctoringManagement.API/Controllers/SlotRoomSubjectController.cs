using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

    public class SlotRoomSubjectController : BaseApiController
    {
        private readonly ISlotRoomSubjectService _SlotRoomSubjectService;

        public SlotRoomSubjectController(ISlotRoomSubjectService SlotRoomSubjectService)
        {
            _SlotRoomSubjectService = SlotRoomSubjectService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SlotRoomSubject>> GetSlotRoomSubject(string id)
        {
            var SlotRoomSubject = await _SlotRoomSubjectService.GetSlotRoomSubjectByIdAsync(id);
            if (SlotRoomSubject == null)
            {
                return NotFound();
            }
            return SlotRoomSubject;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlotRoomSubject>>> GetAllSlotRoomSubjects()
        {
            var SlotRoomSubjects = await _SlotRoomSubjectService.GetAllSlotRoomSubjectsAsync();
            return Ok(SlotRoomSubjects);
        }

        [HttpPost]
        public async Task<ActionResult<SlotRoomSubject>> CreateSlotRoomSubject([FromBody] SlotRoomSubject SlotRoomSubject)
        {
            var createdSlotRoomSubject = await _SlotRoomSubjectService.CreateSlotRoomSubjectAsync(SlotRoomSubject);
            return CreatedAtAction(nameof(GetSlotRoomSubject), new { id = createdSlotRoomSubject.SlotRoomSubjectId }, createdSlotRoomSubject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlotRoomSubject(string id, [FromBody]SlotRoomSubject SlotRoomSubject)
        {
            if (id != SlotRoomSubject.SlotRoomSubjectId)
            {
                return BadRequest();
            }

            await _SlotRoomSubjectService.UpdateSlotRoomSubjectAsync(SlotRoomSubject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlotRoomSubject(string id)
        {
            await _SlotRoomSubjectService.DeleteSlotRoomSubjectAsync(id);
            return NoContent();
        }
    }
}
