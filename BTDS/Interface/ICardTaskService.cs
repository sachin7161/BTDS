using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface ICardTaskService
    {
        Task<List<CardTaskResponseDto>> GetAllCardTasks();

        Task<CardTaskResponseDto> GetCardTask(int cardTaskId);

        Task<CardTaskResponseDto> AddCardTask(CardTaskCreateDto dto);

        Task<CardTaskResponseDto> UpdateCardTask(CardTaskUpdateDto dto);

        Task<CardTaskResponseDto> DeleteCardTask(int cardTaskId);
    }
}
