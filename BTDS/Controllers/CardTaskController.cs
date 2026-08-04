using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTaskController : ControllerBase
    {
        private readonly ICardTaskService _cardTaskService;

        public CardTaskController(ICardTaskService cardTaskService)
        {
            _cardTaskService = cardTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCardTasks()
        {
            var result = await _cardTaskService.GetAllCardTasks();

            return Ok(new ApiResponse<List<CardTaskResponseDto>>
            {
                Success = true,
                Message = "Card Tasks fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardTask(int id)
        {
            var result = await _cardTaskService.GetCardTask(id);

            return Ok(new ApiResponse<CardTaskResponseDto>
            {
                Success = true,
                Message = "Card Task fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCardTask(CardTaskCreateDto dto)
        {
            var result = await _cardTaskService.AddCardTask(dto);

            return Ok(new ApiResponse<CardTaskResponseDto>
            {
                Success = true,
                Message = "Card Task created successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardTask(CardTaskUpdateDto dto)
        {
            var result = await _cardTaskService.UpdateCardTask(dto);

            return Ok(new ApiResponse<CardTaskResponseDto>
            {
                Success = true,
                Message = "Card Task updated successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardTask(int id)
        {
            var result = await _cardTaskService.DeleteCardTask(id);

            return Ok(new ApiResponse<CardTaskResponseDto>
            {
                Success = true,
                Message = "Card Task deleted successfully.",
                Data = result,
                Errors = []
            });
        }
    }
}
