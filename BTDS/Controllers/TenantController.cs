using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTenants() 
        { 
            var result = await _tenantService.GetAllTenants(); 
            return Ok(result); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenant(int id) 
        { 
            var result = await _tenantService.GetTenant(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTenant(TenantCreateDto dto) 
        { 
            var result = await _tenantService.AddTenant(dto); 
            return Ok(result); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTenant(TenantUpdateDto dto)
        {
            var result= await _tenantService.UpdateTenant(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            var result= await _tenantService.DeleteTenant(id);
            return Ok(result);
        }
    }
}
