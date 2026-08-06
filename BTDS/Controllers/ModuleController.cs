using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            var result = await _moduleService.GetAllModules();

            return Ok(new ApiResponse<List<ModuleResponseDto>>
            {
                Success = true,
                Message = "Modules fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule(int id)
        {
            var result = await _moduleService.GetModule(id);

            return Ok(new ApiResponse<ModuleResponseDto>
            {
                Success = true,
                Message = "Module fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleCreateDto dto)
        {
            var result = await _moduleService.AddModule(dto);

            return Ok(new ApiResponse<ModuleResponseDto>
            {
                Success = true,
                Message = "Module created successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModule(ModuleUpdateDto dto)
        {
            var result = await _moduleService.UpdateModule(dto);

            return Ok(new ApiResponse<ModuleResponseDto>
            {
                Success = true,
                Message = "Module updated successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var result = await _moduleService.DeleteModule(id);

            return Ok(new ApiResponse<ModuleResponseDto>
            {
                Success = true,
                Message = "Module deleted successfully.",
                Data = result,
                Errors = []
            });
        }
    }
}