using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class CardResourceService : ICardResourceService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<CardResourceService> _logger;
        public CardResourceService(BtdsdbContext context,ILogger<CardResourceService> logger)
        {
           _context=context;
            _logger= logger;
        }
        public async Task<CardResourceResponseDto> AddCardResource(CardResourceCreateDto dto)
        {
            _logger.LogInformation("Card Resource creation started.");

            var card = await _context.Cards.FindAsync(dto.CardId);

            if (card == null)
                throw new Exception("Card not found.");

            var resourceType = await _context.ResourceTypes.FindAsync(dto.ResourceTypeId);

            if (resourceType == null)
                throw new Exception("Resource Type not found.");

            CardResource resource = new CardResource()
            {
                CardId = dto.CardId,
                ResourceTypeId = dto.ResourceTypeId,
                Title = dto.Title,
                Url = dto.Url,
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                Thumbnail = dto.Thumbnail,
                SequenceNo = dto.SequenceNo,
                IsDownloadable = dto.IsDownloadable,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.CardResources.Add(resource);
            await _context.SaveChangesAsync();

            return new CardResourceResponseDto()
            {
                CardResourceId = resource.CardResourceId,
                CardId = resource.CardId,
                ResourceTypeId = resource.ResourceTypeId,
                Title = resource.Title,
                Url = resource.Url,
                FileName = resource.FileName,
                FilePath = resource.FilePath,
                Thumbnail = resource.Thumbnail,
                SequenceNo = resource.SequenceNo,
                IsDownloadable = resource.IsDownloadable,
                IsActive = resource.IsActive,
                CreatedAt = resource.CreatedAt
            };
        }

        public async Task<CardResourceResponseDto> DeleteCardResource(int cardResourceId)
        {
            var resource = await _context.CardResources
        .FirstOrDefaultAsync(x => x.CardResourceId == cardResourceId && !x.IsDeleted);

            if (resource == null)
                throw new Exception("Card Resource not found.");

            resource.IsDeleted = true;
            resource.IsActive = false;
            resource.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new CardResourceResponseDto()
            {
                CardResourceId = resource.CardResourceId,
                CardId = resource.CardId,
                ResourceTypeId = resource.ResourceTypeId,
                Title = resource.Title,
                Url = resource.Url,
                FileName = resource.FileName,
                FilePath = resource.FilePath,
                Thumbnail = resource.Thumbnail,
                SequenceNo = resource.SequenceNo,
                IsDownloadable = resource.IsDownloadable,
                IsActive = resource.IsActive,
                CreatedAt = resource.CreatedAt
            };
        }

        public async Task<List<CardResourceResponseDto>> GetAllCardResources()
        {
            var resources = await _context.CardResources
        .Where(x => !x.IsDeleted)
        .OrderBy(x => x.SequenceNo)
        .ToListAsync();

            List<CardResourceResponseDto> response = new();

            foreach (var item in resources)
            {
                response.Add(new CardResourceResponseDto()
                {
                    CardResourceId = item.CardResourceId,
                    CardId = item.CardId,
                    ResourceTypeId = item.ResourceTypeId,
                    Title = item.Title,
                    Url = item.Url,
                    FileName = item.FileName,
                    FilePath = item.FilePath,
                    Thumbnail = item.Thumbnail,
                    SequenceNo = item.SequenceNo,
                    IsDownloadable = item.IsDownloadable,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;
        }

        public async Task<CardResourceResponseDto> GetCardResource(int cardResourceId)
        {
            var resource = await _context.CardResources
        .FirstOrDefaultAsync(x => x.CardResourceId == cardResourceId && !x.IsDeleted);

            if (resource == null)
                throw new Exception("Card Resource not found.");

            return new CardResourceResponseDto()
            {
                CardResourceId = resource.CardResourceId,
                CardId = resource.CardId,
                ResourceTypeId = resource.ResourceTypeId,
                Title = resource.Title,
                Url = resource.Url,
                FileName = resource.FileName,
                FilePath = resource.FilePath,
                Thumbnail = resource.Thumbnail,
                SequenceNo = resource.SequenceNo,
                IsDownloadable = resource.IsDownloadable,
                IsActive = resource.IsActive,
                CreatedAt = resource.CreatedAt
            };
        }

        public async Task<CardResourceResponseDto> UpdateCardResource(CardResourceUpdateDto dto)
        {
            var resource = await _context.CardResources
         .FirstOrDefaultAsync(x => x.CardResourceId == dto.CardResourceId && !x.IsDeleted);

            if (resource == null)
                throw new Exception("Card Resource not found.");

            resource.CardId = dto.CardId;
            resource.ResourceTypeId = dto.ResourceTypeId;
            resource.Title = dto.Title;
            resource.Url = dto.Url;
            resource.FileName = dto.FileName;
            resource.FilePath = dto.FilePath;
            resource.Thumbnail = dto.Thumbnail;
            resource.SequenceNo = dto.SequenceNo;
            resource.IsDownloadable = dto.IsDownloadable;
            resource.IsActive = dto.IsActive;
            resource.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new CardResourceResponseDto()
            {
                CardResourceId = resource.CardResourceId,
                CardId = resource.CardId,
                ResourceTypeId = resource.ResourceTypeId,
                Title = resource.Title,
                Url = resource.Url,
                FileName = resource.FileName,
                FilePath = resource.FilePath,
                Thumbnail = resource.Thumbnail,
                SequenceNo = resource.SequenceNo,
                IsDownloadable = resource.IsDownloadable,
                IsActive = resource.IsActive,
                CreatedAt = resource.CreatedAt
            };
        }
    }
}
