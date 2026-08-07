using BTDS.DTOs;
using BTDS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamAttemptController : ControllerBase
    {
        private readonly ExamAttemptService _examAttemptService;

        public ExamAttemptController(ExamAttemptService examAttemptService)
        {
            _examAttemptService = examAttemptService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamAttempts()
        {
            var result=await _examAttemptService.GetAllExamAttempts();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamAttempt(long id)
        {
            var result = await _examAttemptService
                .GetExamAttempt(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddExamAttempt(
            ExamAttemptCreateDto dto)
        {
            var result = await _examAttemptService
                .AddExamAttempt(dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExamAttempt(
            ExamAttemptUpdateDto dto)
        {
            var result = await _examAttemptService
                .UpdateExamAttempt(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamAttempt(long id)
        {
            var result = await _examAttemptService
                .DeleteExamAttempt(id);

            return Ok(result);
        }
    }
}
