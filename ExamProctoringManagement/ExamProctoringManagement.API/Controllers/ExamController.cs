using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    public class ExamController : BaseApiController
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(string id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return exam;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetAllExams()
        {
            var exams = await _examService.GetAllExamsAsync();
            return Ok(exams);
        }

        [HttpPost]
        public async Task<ActionResult<Exam>> CreateExam([FromBody] ExamDTO exam)
        {
            var createdExam = await _examService.CreateExamAsync(exam);
            return Ok(createdExam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(string id, [FromBody] ExamDTO exam)
        {
            if (id != exam.ExamId)
            {
                return BadRequest();
            }

            await _examService.UpdateExamAsync(exam);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(string id)
        {
            await _examService.DeleteExamAsync(id);
            return NoContent();
        }

        [HttpGet("semester")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExamsBySemesterId(string semesterId)
        {
            var exams = await _examService.GetExamsBySemesterIdAsync(semesterId);
            return Ok(exams);
        }
    }
}
