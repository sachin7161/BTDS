using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface ICardsService
    {
        Task<List<CardResponseDto>> GetAllCards();
        Task<CardResponseDto> GetCard(int CardId);
        Task<CardResponseDto> AddCard(CardCreateDto dto);
        Task<CardResponseDto>UpdateCard(CardUpdateDto dto);
        Task<CardResponseDto> DeleteCard(int cardid);
    }
}
