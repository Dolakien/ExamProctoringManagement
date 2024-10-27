using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
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

        [HttpPost]
        public async Task<ActionResult<Report>> CreateReport([FromBody] Report Report)
        {
            var createdReport = await _ReportService.CreateReportAsync(Report);
            return CreatedAtAction(nameof(GetReport), new { id = createdReport.ReportId }, createdReport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(string id, [FromBody] Report Report)
        {
            if (id != Report.ReportId)
            {
                return BadRequest();
            }

            await _ReportService.UpdateReportAsync(Report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(string id)
        {
            await _ReportService.DeleteReportAsync(id);
            return NoContent();
        }
    }
}
