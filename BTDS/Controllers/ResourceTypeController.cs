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
    public class ResourceTypeController : ControllerBase
    {
        private readonly IResourceTypeService _resourceTypeService;

        public ResourceTypeController(IResourceTypeService resourceTypeService)
        {
            _resourceTypeService = resourceTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResourceTypes()
        {
            var result = await _resourceTypeService.GetAllResourceTypes();

            return Ok(new ApiResponse<List<ResourceTypeResponseDto>>
            {
                Success = true,
                Message = "Resource Types fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceType(int id)
        {
            var result = await _resourceTypeService.GetResourceType(id);

            return Ok(new ApiResponse<ResourceTypeResponseDto>
            {
                Success = true,
                Message = "Resource Type fetched successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddResourceType(ResourceTypeCreateDto dto)
        {
            var result = await _resourceTypeService.AddResourceType(dto);

            return Ok(new ApiResponse<ResourceTypeResponseDto>
            {
                Success = true,
                Message = "Resource Type created successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResourceType(ResourceTypeUpdateDto dto)
        {
            var result = await _resourceTypeService.UpdateResourceType(dto);

            return Ok(new ApiResponse<ResourceTypeResponseDto>
            {
                Success = true,
                Message = "Resource Type updated successfully.",
                Data = result,
                Errors = []
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceType(int id)
        {
            var result = await _resourceTypeService.DeleteResourceType(id);

            return Ok(new ApiResponse<ResourceTypeResponseDto>
            {
                Success = true,
                Message = "Resource Type deleted successfully.",
                Data = result,
                Errors = []
            });
        }
    }
}
