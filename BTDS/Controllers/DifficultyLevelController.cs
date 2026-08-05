using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyLevelController : ControllerBase
    {
        private readonly IDifficultyLevelService _difficultyLevelService;

        public DifficultyLevelController(IDifficultyLevelService difficultyLevelService)
        {
            _difficultyLevelService = difficultyLevelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDifficultyLevels()
        {
            var result = await _difficultyLevelService.GetAllDifficultyLevels();

            return Ok(new ApiResponse<List<DifficultyLevelResponseDto>>
            {
                Success = true,
                Message = "Difficulty Levels fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDifficultyLevel(int id)
        {
            var result = await _difficultyLevelService.GetDifficultyLevel(id);

            return Ok(new ApiResponse<DifficultyLevelResponseDto>
            {
                Success = true,
                Message = "Difficulty Level fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddDifficultyLevel(DifficultyLevelCreateDto dto)
        {
            var result = await _difficultyLevelService.AddDifficultyLevel(dto);

            return Ok(new ApiResponse<DifficultyLevelResponseDto>
            {
                Success = true,
                Message = "Difficulty Level created successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDifficultyLevel(DifficultyLevelUpdateDto dto)
        {
            var result = await _difficultyLevelService.UpdateDifficultyLevel(dto);

            return Ok(new ApiResponse<DifficultyLevelResponseDto>
            {
                Success = true,
                Message = "Difficulty Level updated successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficultyLevel(int id)
        {
            var result = await _difficultyLevelService.DeleteDifficultyLevel(id);

            return Ok(new ApiResponse<DifficultyLevelResponseDto>
            {
                Success = true,
                Message = "Difficulty Level deleted successfully.",
                Data = result,
                Errors = []
            });
        }
    }
}
