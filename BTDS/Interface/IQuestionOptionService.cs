using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IQuestionOptionService
    {
        Task<List<QuestionOptionResponseDto>> GetAllQuestionOptions();

        Task<QuestionOptionResponseDto> GetQuestionOption(long optionId);

        Task<QuestionOptionResponseDto> AddQuestionOption(QuestionOptionCreateDto dto);

        Task<QuestionOptionResponseDto> UpdateQuestionOption(QuestionOptionUpdateDto dto);

        Task<QuestionOptionResponseDto> DeleteQuestionOption(long optionId);
    }
}
