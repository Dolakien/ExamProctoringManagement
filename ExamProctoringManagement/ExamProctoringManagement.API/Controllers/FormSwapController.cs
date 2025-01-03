﻿using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.Service.Usecases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExamProctoringManagement.API.Controllers
{
    public class FormSwapController : BaseApiController
    {
        private readonly IFormSwapService _formSwapService;
        private readonly ISlotService _slotService;
        public FormSwapController(IFormSwapService formSwapService, ISlotService slotService)
        {
            _formSwapService = formSwapService;
            _slotService = slotService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormSwap>> GetFormSwap(string id)
        {
            var formSwap = await _formSwapService.GetFormSwapByIdAsync(id);
            if (formSwap == null)
            {
                return NotFound();
            }
            return formSwap;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormSwap>>> GetAllFormSwaps()
        {
            var formSwaps = await _formSwapService.GetAllFormSwapsAsync();
            return Ok(formSwaps);
        }

        [HttpPost]
        public async Task<ActionResult<FormSwap>> CreateFormSwap(string examId, [FromBody] CreateFormSwapDto createFormSwapDto)
        {
            if (createFormSwapDto == null)
            {
                return BadRequest();
            }

            if (createFormSwapDto.FromSlot == createFormSwapDto.ToSlot)
            {
                return BadRequest();
            }

            var slots = await _slotService.GetAvailableSlotsByExamId(examId);
            if (!slots.Any(s => s.SlotId == createFormSwapDto.ToSlot))
            {
                return BadRequest("Slot đã chọn không có sẵn");
            }

            var createdFormSwap = await _formSwapService.CreateFormSwapAsync(createFormSwapDto);
            return CreatedAtAction(nameof(GetFormSwap), new { id = createdFormSwap.FormId }, createdFormSwap);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFormSwap([FromBody] UpdateFormSwapDto updateFormSwapDto)
        {
            var response = await _formSwapService.UpdateFormSwapAsync(updateFormSwapDto);
            if (response != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_UPDATE_CODE,
                     Const.SUCCESS_UPDATE_MSG,
                     "FormSwap is Updated successfully"
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormSwap(string id)
        {
            await _formSwapService.DeleteFormSwapAsync(id);
            return NoContent();
        }
    }
}
