using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStagesService _stagesService;
        private readonly ILogger<StageController> _logger;

        public StageController(IStagesService stagesService,ILogger<StageController> logger)
        {
            _stagesService= stagesService;  
            _logger = logger;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllStage()
        {
            _logger.LogInformation("GetAll Stage Api Called");
            var result = await _stagesService.GetAllStage();
            _logger.LogInformation("Stage Added Successfully");
            return Ok(new ApiResponse<IEnumerable<StageResponseDto>>
            {
                Success = true,
                Message = "Get Stage Successfully",
                Data = result ?? Enumerable.Empty<StageResponseDto>(),
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetStage(int id)
        {
            _logger.LogInformation("GetStage Api Called");
            var result=await _stagesService.GetStage(id);

          
            return Ok(new ApiResponse<StageResponseDto>
            {
                Success= true,
                Message="Get Stage Successfully",
                Data=result,
                Errors = []
            });
        }
        [HttpPost]
        public async Task<IActionResult>AddStage(StageCreateDto dto)
        {
            _logger.LogInformation("Add Api called");
            var result=await _stagesService.AddStage(dto);
            return Ok(new ApiResponse<StageResponseDto>
            {
                Success=true,
                Message="Add Stage Successfully",
                Data= result,
                Errors = []
                
            });
        }

        [HttpPut]
        public async Task<IActionResult>UpdateStage(StageUpdateDto dto)
        {
            _logger.LogInformation("Update Stage Api Called");
            var result=await _stagesService.UpdateStage(dto);
            return Ok(new ApiResponse<StageResponseDto>
            {
                Success=true,
                Message="Stage Update Successfully",
                Data=result,
                Errors = []
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>StageDelete(int id)
        {
            _logger.LogInformation("Stage Deleted Api Called");
            var result = await _stagesService.DeleteStage(id);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Stage Deleted Successfully",
                Data = result ?? string.Empty,
                Errors = []
            });
        }
    }
      
}
