using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTDS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardsService _cardservices;
        private readonly ILogger<CardController> _logger;
        public CardController(ICardsService cardservices,ILogger<CardController> logger)
        {
            _cardservices = cardservices;
            _logger= logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCard()
        {
            _logger.LogInformation("GetAllCard Api called");
            var result = await _cardservices.GetAllCards();

            return Ok(new ApiResponse<List<CardResponseDto>>
            {
                Success = true,
                Message = "Get All Cards",
                Data = result ?? new List<CardResponseDto>(),
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetCard(int id)
        {
            _logger.LogInformation("GetCard Api called");
            var result=await _cardservices.GetCard(id);

            return Ok(new ApiResponse<CardResponseDto>{
               Success = true,
               Message="Get Card Card Successfully",
               Data = result,
                Errors = []
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(CardCreateDto dto)
        {
            _logger.LogInformation("Add Card Api Called");
            var result=await _cardservices.AddCard(dto);
            return Ok(new ApiResponse<CardResponseDto>{
                Success = true,
                Message="AddCard Successfully",
                Data= result,
                Errors = []
            });
        }
        [HttpPut]
        public async Task<IActionResult>UpdateCard(CardUpdateDto dto)
        {
            _logger.LogInformation("Update Card Api  Called");
            var result = await _cardservices.UpdateCard(dto);
            return Ok(new ApiResponse<CardResponseDto>
            {
                Success=true,
                Message="Card Update Successfully",
                Data=result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>CardDelete(int id)
        {
            _logger.LogInformation("Deleted card Api called");
            var result=await _cardservices.DeleteCard(id);
           
                return Ok(new ApiResponse<CardResponseDto>
                {
                    Success = true,
                    Message = "Card Delete Successfull",
                    Data = result,
                    Errors = []
                });
            
        }
    }
}
