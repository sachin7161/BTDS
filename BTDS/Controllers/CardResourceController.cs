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
    public class CardResourceController : ControllerBase
    {
        private readonly ICardResourceService _cardResourceService;

        public CardResourceController(ICardResourceService cardResourceService)
        {
            _cardResourceService = cardResourceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCardResources()
        {
            var result = await _cardResourceService.GetAllCardResources();

            return Ok(new ApiResponse<List<CardResourceResponseDto>>
            {
                Success = true,
                Message = "Card Resources fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardResource(int id)
        {
            var result = await _cardResourceService.GetCardResource(id);

            return Ok(new ApiResponse<CardResourceResponseDto>
            {
                Success = true,
                Message = "Card Resource fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCardResource(CardResourceCreateDto dto)
        {
            var result = await _cardResourceService.AddCardResource(dto);

            return Ok(new ApiResponse<CardResourceResponseDto>
            {
                Success = true,
                Message = "Card Resource created successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardResource(CardResourceUpdateDto dto)
        {
            var result = await _cardResourceService.UpdateCardResource(dto);

            return Ok(new ApiResponse<CardResourceResponseDto>
            {
                Success = true,
                Message = "Card Resource updated successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardResource(int id)
        {
            var result = await _cardResourceService.DeleteCardResource(id);

            return Ok(new ApiResponse<CardResourceResponseDto>
            {
                Success = true,
                Message = "Card Resource deleted successfully.",
                Data = result,
                Errors = []
            });
        }
    }
}
