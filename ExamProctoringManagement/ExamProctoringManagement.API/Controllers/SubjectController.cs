using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.Service.Usecases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

    public class SubjectController : BaseApiController
    {
        private readonly ISubjectService _SubjectService;

        public SubjectController(ISubjectService SubjectService)
        {
            _SubjectService = SubjectService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(string id)
        {
            var Subject = await _SubjectService.GetSubjectByIdAsync(id);
            if (Subject == null)
            {
                return NotFound();
            }
            return Subject;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            var Subjects = await _SubjectService.GetAllSubjectsAsync();
            return Ok(Subjects);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> CreateSubject([FromBody] Subject Subject)
        {
            var createdSubject = await _SubjectService.CreateSubjectAsync(Subject);
            return CreatedAtAction(nameof(GetSubject), new { id = createdSubject.SubjectId }, createdSubject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(string id, [FromBody] Subject Subject)
        {
            if (id != Subject.SubjectId)
            {
                return BadRequest();
            }

            await _SubjectService.UpdateSubjectAsync(Subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(string id)
        {
            await _SubjectService.DeleteSubjectAsync(id);
            return NoContent();
        }

        [HttpGet("exam")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjectsByExamId(string examId)
        {
            var Subjects = await _SubjectService.GetSubjectsByExamIdAsync(examId);
            return Ok(Subjects);
        }
    }
}
