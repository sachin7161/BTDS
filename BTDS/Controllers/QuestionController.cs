using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var result = await _questionService.GetAllQuestions();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(long id)
        {
            var result = await _questionService.GetQuestion(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(
            QuestionCreateDto dto)
        {
            var result = await _questionService.AddQuestion(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(
            QuestionUpdateDto dto)
        {
            var result = await _questionService.UpdateQuestion(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(long id)
        {
            var result = await _questionService.DeleteQuestion(id);
            return Ok(result);
        }
    }

}
