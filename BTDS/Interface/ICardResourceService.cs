using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface ICardResourceService
    {
        Task<List<CardResourceResponseDto>> GetAllCardResources();

        Task<CardResourceResponseDto> GetCardResource(int cardResourceId);

        Task<CardResourceResponseDto> AddCardResource(CardResourceCreateDto dto);

        Task<CardResourceResponseDto> UpdateCardResource(CardResourceUpdateDto dto);

        Task<CardResourceResponseDto> DeleteCardResource(int cardResourceId);
    }
}
