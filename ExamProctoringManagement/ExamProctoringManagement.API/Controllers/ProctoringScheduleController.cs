using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProctoringScheduleController : BaseApiController
    {
        private readonly IProctoringScheduleService _ProctoringScheduleService;

        public ProctoringScheduleController(IProctoringScheduleService ProctoringScheduleService)
        {
            _ProctoringScheduleService = ProctoringScheduleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProctoringSchedule>> GetProctoringSchedule(string id)
        {
            var ProctoringSchedule = await _ProctoringScheduleService.GetProctoringScheduleByIdAsync(id);
            if (ProctoringSchedule == null)
            {
                return NotFound();
            }
            return ProctoringSchedule;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProctoringSchedule>>> GetAllProctoringSchedules()
        {
            var ProctoringSchedules = await _ProctoringScheduleService.GetAllProctoringSchedulesAsync();
            return Ok(ProctoringSchedules);
        }

        [HttpPost]
        public async Task<ActionResult<ProctoringSchedule>> CreateProctoringSchedule(ProctoringSchedule ProctoringSchedule)
        {
            var createdProctoringSchedule = await _ProctoringScheduleService.CreateProctoringScheduleAsync(ProctoringSchedule);
            return CreatedAtAction(nameof(GetProctoringSchedule), new { id = createdProctoringSchedule.ScheduleId }, createdProctoringSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProctoringSchedule(string id, ProctoringSchedule ProctoringSchedule)
        {
            if (id != ProctoringSchedule.ScheduleId)
            {
                return BadRequest();
            }

            await _ProctoringScheduleService.UpdateProctoringScheduleAsync(ProctoringSchedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProctoringSchedule(string id)
        {
            await _ProctoringScheduleService.DeleteProctoringScheduleAsync(id);
            return NoContent();
        }
    }
}
