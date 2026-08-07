using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IExamAttemptService
    {
        Task<List<ExamAttemptResponseDto>> GetAllExamAttempts();

        Task<ExamAttemptResponseDto> GetExamAttempt(long attemptId);

        Task<ExamAttemptResponseDto> AddExamAttempt(ExamAttemptCreateDto dto);

        Task<ExamAttemptResponseDto> UpdateExamAttempt(ExamAttemptUpdateDto dto);

        Task<ExamAttemptResponseDto> DeleteExamAttempt(long attemptId);
    }
}
