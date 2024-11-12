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

    public class ReportController : BaseApiController
    {
        private readonly IReportService _ReportService;

        public ReportController(IReportService ReportService)
        {
            _ReportService = ReportService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(string id)
        {
            var Report = await _ReportService.GetReportByIdAsync(id);
            if (Report == null)
            {
                return NotFound();
            }
            return Report;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetAllReports()
        {
            var Reports = await _ReportService.GetAllReportsAsync();
            return Ok(Reports);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Report>> CreateReport([FromBody] ReportCreateDto Report)
        {           
            var createdReport = await _ReportService.CreateReportAsync(Report);
            return CreatedAtAction(nameof(GetReport), new { id = createdReport.ReportId }, createdReport);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReport([FromBody] ReportUpdateDto Report)
        {
            var response = await _ReportService.UpdateReportAsync(Report);
            if (response != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_UPDATE_CODE,
                     Const.SUCCESS_UPDATE_MSG,
                     "Report is Updated successfully"
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReport(string id)
        {
            await _ReportService.DeleteReportAsync(id);
            return NoContent();
        }

        [HttpGet("userId")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsByUserId(string userId)
        {
            var Reports = await _ReportService.GetReportsByUserIdAsync(userId);
            return Ok(Reports);
        }

        [HttpGet("paid")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsByIsPaid(bool p)
        {
            var Reports = await _ReportService.GetReportsByIsPaidAsync(p);
            return Ok(Reports);
        }

        [HttpGet("month")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsByMonth(int month, int year)
        {
            var Reports = await _ReportService.GetReportsByMonthAsync(month, year);
            return Ok(Reports);
        }
    }
}
