using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IExamInstructionService
    {
        Task<List<ExamInstructionResponseDto>> GetAllExamInstructions(); 
        Task<ExamInstructionResponseDto> GetExamInstruction(long instructionId);
        Task<ExamInstructionResponseDto> AddExamInstruction(ExamInstructionCreateDto dto); 
        Task<ExamInstructionResponseDto> UpdateExamInstruction(ExamInstructionUpdateDto dto); 
        Task<ExamInstructionResponseDto> DeleteExamInstruction(long instructionId);
    }
}
