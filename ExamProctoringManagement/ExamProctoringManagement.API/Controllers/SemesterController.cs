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
    public class SemesterController : BaseApiController
    {
        private readonly ISemesterService _SemesterService;

        public SemesterController(ISemesterService SemesterService)
        {
            _SemesterService = SemesterService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetSemester(string id)
        {
            var Semester = await _SemesterService.GetSemesterByIdAsync(id);
            if (Semester == null)
            {
                return NotFound();
            }
            return Semester;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> GetAllSemesters()
        {
            var Semesters = await _SemesterService.GetAllSemestersAsync();
            return Ok(Semesters);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Semester>> CreateSemester([FromBody] SemesterCreateDto Semester)
        {
            var createdSemester = await _SemesterService.CreateSemesterAsync(Semester);
            return CreatedAtAction(nameof(GetSemester), new { id = createdSemester.SemesterId }, createdSemester);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSemester([FromBody] SemesterUpdateDto Semester)
        {
            var response = await _SemesterService.UpdateSemesterAsync(Semester);
            if (response != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_UPDATE_CODE,
                     Const.SUCCESS_UPDATE_MSG,
                     "Semester is Updated successfully"
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSemester(string id)
        {
            await _SemesterService.DeleteSemesterAsync(id);
            return NoContent();
        }
    }
}
