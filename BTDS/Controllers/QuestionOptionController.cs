using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionOptionController : ControllerBase
    {
        private readonly IQuestionOptionService _questionOptionService;

        public QuestionOptionController(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllQuestionOptions()
        {
            var result = await _questionOptionService
                .GetAllQuestionOptions();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionOption(long id)
        {
            var result = await _questionOptionService
                .GetQuestionOption(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestionOption(
            QuestionOptionCreateDto dto)
        {
            var result = await _questionOptionService
                .AddQuestionOption(dto);

            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateQuestionOption(
            QuestionOptionUpdateDto dto)
        {
            var result = await _questionOptionService
                .UpdateQuestionOption(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionOption(long id)
        {
            var result = await _questionOptionService
                .DeleteQuestionOption(id);

            return Ok(result);
        }
    }
}
