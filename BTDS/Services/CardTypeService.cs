using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class CardTypeService : ICardTypeService
    {
        public readonly BtdsdbContext _context;
        public readonly ILogger<CardTypeService> _logger;
        public CardTypeService(BtdsdbContext context, ILogger<CardTypeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CardTypeResponseDto> AddCardType(CardTypeCreateDto dto)
        {
            _logger.LogInformation("Card Type creation started.");

            var isExist = await _context.CardTypes
                .AnyAsync(x => x.Name == dto.Name && !x.IsDeleted);

            if (isExist)
                throw new Exception("Card Type already exists.");

            CardType cardType = new CardType()
            {
                Name = dto.Name,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.CardTypes.Add(cardType);
            await _context.SaveChangesAsync();

            return new CardTypeResponseDto()
            {
                CardTypeId = cardType.CardTypeId,
                Name = cardType.Name,
                IsActive = cardType.IsActive,
                CreatedAt = cardType.CreatedAt
            };
        }

        public async Task<CardTypeResponseDto> DeleteCardType(int cardTypeId)
        {
            var cardType = await _context.CardTypes.FirstOrDefaultAsync(x => x.CardTypeId == cardTypeId && !x.IsDeleted);

            if (cardType == null)
                throw new Exception("Card Type not found.");

            cardType.IsDeleted = true;
            cardType.IsActive = false;
            cardType.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new CardTypeResponseDto()
            {
                CardTypeId = cardType.CardTypeId,
                Name = cardType.Name,
                IsActive = cardType.IsActive,
                CreatedAt = cardType.CreatedAt
            };
        }

        public async Task<List<CardTypeResponseDto>> GetAllCardTypes()
        {
            var cardTypes = await _context.CardTypes
        .Where(x => !x.IsDeleted)
        .ToListAsync();

            List<CardTypeResponseDto> response = new();

            foreach (var item in cardTypes)
            {
                response.Add(new CardTypeResponseDto()
                {
                    CardTypeId = item.CardTypeId,
                    Name = item.Name,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;
        }

        public async Task<CardTypeResponseDto> GetCardType(int cardTypeId)
        {
            var cardType = await _context.CardTypes
        .FirstOrDefaultAsync(x => x.CardTypeId == cardTypeId && !x.IsDeleted);

            if (cardType == null)
                throw new Exception("Card Type not found.");

            return new CardTypeResponseDto()
            {
                CardTypeId = cardType.CardTypeId,
                Name = cardType.Name,
                IsActive = cardType.IsActive,
                CreatedAt = cardType.CreatedAt
            };
        }

        public async Task<CardTypeResponseDto> UpdateCardType(CardTypeUpdateDto dto)
        {
            var cardType = await _context.CardTypes
        .FirstOrDefaultAsync(x => x.CardTypeId == dto.CardTypeId && !x.IsDeleted);

            if (cardType == null)
                throw new Exception("Card Type not found.");

            var isExist = await _context.CardTypes.AnyAsync(x =>
                x.Name == dto.Name &&
                x.CardTypeId != dto.CardTypeId &&
                !x.IsDeleted);

            if (isExist)
                throw new Exception("Card Type already exists.");

            cardType.Name = dto.Name;
            cardType.IsActive = dto.IsActive;
            cardType.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new CardTypeResponseDto()
            {
                CardTypeId = cardType.CardTypeId,
                Name = cardType.Name,
                IsActive = cardType.IsActive,
                CreatedAt = cardType.CreatedAt
            };
        }
    }
}
