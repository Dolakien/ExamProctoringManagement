using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<Semester>> CreateSemester(Semester Semester)
        {
            var createdSemester = await _SemesterService.CreateSemesterAsync(Semester);
            return CreatedAtAction(nameof(GetSemester), new { id = createdSemester.SemesterId }, createdSemester);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemester(string id, Semester Semester)
        {
            if (id != Semester.SemesterId)
            {
                return BadRequest();
            }

            await _SemesterService.UpdateSemesterAsync(Semester);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(string id)
        {
            await _SemesterService.DeleteSemesterAsync(id);
            return NoContent();
        }
    }
}
