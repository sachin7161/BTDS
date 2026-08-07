using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IQuestionService
    {
        Task<List<QuestionResponseDto>> GetAllQuestions();

        Task<QuestionResponseDto> GetQuestion(long questionId);

        Task<QuestionResponseDto> AddQuestion(QuestionCreateDto dto);

        Task<QuestionResponseDto> UpdateQuestion(QuestionUpdateDto dto);

        Task<QuestionResponseDto> DeleteQuestion(long questionId);
    }
}
