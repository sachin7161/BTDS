using BTDS.DTOs;
using BTDS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamInstructionController : ControllerBase
    {
        private readonly IExamInstructionService _examInstructionService;

        public ExamInstructionController(IExamInstructionService examInstructionService)
        {
            _examInstructionService = examInstructionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamInstructions()
        {
            var result = await _examInstructionService.GetAllExamInstructions();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamInstruction(long id)
        {
            var result = await _examInstructionService.GetExamInstruction(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddExamInstruction(ExamInstructionCreateDto dto)
        {
            var result = await _examInstructionService.AddExamInstruction(dto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExamInstruction(ExamInstructionUpdateDto dto)
        {
            var result = await _examInstructionService.UpdateExamInstruction(dto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamInstruction(long id)
        {
            var result= await _examInstructionService.DeleteExamInstruction(id);
            return Ok(result);
        }
    }
}
