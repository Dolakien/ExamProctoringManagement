using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    public class FormSwapController : BaseApiController
    {
        private readonly IFormSwapService _formSwapService;

        public FormSwapController(IFormSwapService formSwapService)
        {
            _formSwapService = formSwapService;
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
        public async Task<ActionResult<FormSwap>> CreateFormSwap([FromBody]FormSwap formSwap)
        {
            var createdFormSwap = await _formSwapService.CreateFormSwapAsync(formSwap);
            return CreatedAtAction(nameof(GetFormSwap), new { id = createdFormSwap.FormId }, createdFormSwap);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFormSwap(string id, [FromBody] FormSwap formSwap)
        {
            if (id != formSwap.FormId)
            {
                return BadRequest();
            }

            await _formSwapService.UpdateFormSwapAsync(formSwap);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormSwap(string id)
        {
            await _formSwapService.DeleteFormSwapAsync(id);
            return NoContent();
        }
    }
}
