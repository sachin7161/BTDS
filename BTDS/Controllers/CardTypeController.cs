using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeController : ControllerBase
    {
        private readonly ICardTypeService _cardTypeService;

        public CardTypeController(ICardTypeService cardTypeService)
        {
            _cardTypeService = cardTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCardTypes()
        {
            var result = await _cardTypeService.GetAllCardTypes();

            return Ok(new ApiResponse<List<CardTypeResponseDto>>
            {
                Success = true,
                Message = "Card Types fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardType(int id)
        {
            var result = await _cardTypeService.GetCardType(id);

            return Ok(new ApiResponse<CardTypeResponseDto>
            {
                Success = true,
                Message = "Card Type fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCardType(CardTypeCreateDto dto)
        {
            var result = await _cardTypeService.AddCardType(dto);

            return Ok(new ApiResponse<CardTypeResponseDto>
            {
                Success = true,
                Message = "Card Type created successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardType(CardTypeUpdateDto dto)
        {
            var result = await _cardTypeService.UpdateCardType(dto);

            return Ok(new ApiResponse<CardTypeResponseDto>
            {
                Success = true,
                Message = "Card Type updated successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardType(int id)
        {
            var result = await _cardTypeService.DeleteCardType(id);

            return Ok(new ApiResponse<CardTypeResponseDto>
            {
                Success = true,
                Message = "Card Type deleted successfully.",
                Data = result,
                Errors = []
            });
        }
    }
}
