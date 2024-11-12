using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.Service.Usecases;
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

        //[HttpPost("create")]
        //public async Task<ActionResult<FormSlot>> CreateFormSlot([FromBody] FormSlot formSlot)
        //{
        //    var createdFormSlot = await _formSlotService.CreateFormSlotAsync(formSlot);
        //    return CreatedAtAction(nameof(GetFormSlot), new { id = createdFormSlot.FormSlotId}, createdFormSlot);
        //}

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFormSlot([FromBody] FormSlotUpdateDto formSlot)
        {
            var response = await _formSlotService.UpdateFormSlotAsync(formSlot);
            if (response != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_UPDATE_CODE,
                     Const.SUCCESS_UPDATE_MSG,
                     "FormSlot is Updated successfully"
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFormSlot(string id)
        {
            await _formSlotService.DeleteFormSlotAsync(id);
            return NoContent();
        }
    }
}
