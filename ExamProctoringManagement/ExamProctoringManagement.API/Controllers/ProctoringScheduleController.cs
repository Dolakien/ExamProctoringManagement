﻿using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

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
        public async Task<ActionResult<ProctoringSchedule>> CreateProctoringSchedule([FromBody] ProctoringScheduleDTO ProctoringSchedule)
        {
            var createdProctoringSchedule = await this._ProctoringScheduleService.CreateProctoringScheduleAsync(ProctoringSchedule);
            return Ok(createdProctoringSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProctoringSchedule(string id, [FromBody] ProctoringScheduleDTO ProctoringSchedule)
        {
            if (id != ProctoringSchedule.ScheduleId)
            {
                return BadRequest();
            }

            await this._ProctoringScheduleService.UpdateProctoringScheduleAsync(ProctoringSchedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProctoringSchedule(string id)
        {
            await _ProctoringScheduleService.DeleteProctoringScheduleAsync(id);
            return NoContent();
        }

        [HttpGet("userId")]
        public async Task<ActionResult<IEnumerable<ProctoringSchedule>>> GetProctoringSchedulesByUserId(string userId)
        {
            var ProctoringSchedules = await _ProctoringScheduleService.GetProctoringSchedulesByUserIdAsync(userId);
            return Ok(ProctoringSchedules);
        }

        [HttpGet("userId/{finish}")]
        public async Task<ActionResult<IEnumerable<ProctoringSchedule>>> GetProctoringSchedulesByUserIdAndIsFinished(string userId, bool finish)
        {
            var ProctoringSchedules = await _ProctoringScheduleService.GetProctoringSchedulesByUserIdAndIsFinishedAsync(userId, finish);
            return Ok(ProctoringSchedules);
        }

        [HttpGet("full/{id}")]
        public async Task<ActionResult<FullProctoringScheduleDto>> GetFullProctoringSchedule(string id)
        {
            var ProctoringSchedule = await _ProctoringScheduleService.GetFullProctoringScheduleByIdAsync(id);
            if (ProctoringSchedule == null)
            {
                return NotFound();
            }
            return ProctoringSchedule;
        }
    }
}
