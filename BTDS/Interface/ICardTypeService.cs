using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface ICardTypeService
    {
        Task<List<CardTypeResponseDto>> GetAllCardTypes();

        Task<CardTypeResponseDto> GetCardType(int cardTypeId);

        Task<CardTypeResponseDto> AddCardType(CardTypeCreateDto dto);

        Task<CardTypeResponseDto> UpdateCardType(CardTypeUpdateDto dto);

        Task<CardTypeResponseDto> DeleteCardType(int cardTypeId);
    }
}
