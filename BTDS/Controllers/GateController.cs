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
    public class GateController : ControllerBase
    {
        private readonly IGateService _gateService;

        public GateController(IGateService gateService)
        {
            _gateService = gateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGates()
        {
            var result = await _gateService.GetAllGates();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGate(int id)
        {
            var result = await _gateService.GetGate(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddGate(GateCreateDto dto)
        {
            var result = await _gateService.AddGate(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGate(GateUpdateDto dto)
        {
            var result = await _gateService.UpdateGate(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGate(int id)
        {
            var result = await _gateService.DeleteGate(id);
            return Ok(result);
        }
    }
}
