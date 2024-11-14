using ExamProctoringManagement.Contract.DTOs;
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
        public async Task<ActionResult<Subject>> CreateSubject([FromBody] SubjectDto Subject)
        {
            var createdSubject = await _SubjectService.CreateSubjectAsync(Subject);
            return Ok(createdSubject);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject([FromBody] SubjectDto Subject)
        {
            var response = await _SubjectService.UpdateSubjectAsync(Subject);
            return Ok(response);
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
