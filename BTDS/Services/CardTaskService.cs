using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class CardTaskService : ICardTaskService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<CardTaskService> _logger;
        public CardTaskService(BtdsdbContext context, ILogger<CardTaskService> logger)
        {
            _context = context;
            _logger=logger;

        }
        public async Task<CardTaskResponseDto> AddCardTask(CardTaskCreateDto dto)
        {
            _logger.LogInformation("Card Task creation started.");

            var card = await _context.Cards.FindAsync(dto.CardId);

            if (card == null)
                throw new Exception("Card not found.");

            CardTask cardTask = new CardTask()
            {
                CardId = dto.CardId,
                Title = dto.Title,
                Description = dto.Description,
                SequenceNo = dto.SequenceNo,
                EstimatedMinutes = dto.EstimatedMinutes,
                IsMandatory = dto.IsMandatory,
                IsSubmissionRequired = dto.IsSubmissionRequired,
                IsApprovalRequired = dto.IsApprovalRequired,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.CardTasks.Add(cardTask);
            await _context.SaveChangesAsync();

            return new CardTaskResponseDto()
            {
                CardTaskId = cardTask.CardTaskId,
                CardId = cardTask.CardId,
                Title = cardTask.Title,
                Description = cardTask.Description,
                SequenceNo = cardTask.SequenceNo,
                EstimatedMinutes = cardTask.EstimatedMinutes,
                IsMandatory = cardTask.IsMandatory,
                IsSubmissionRequired = cardTask.IsSubmissionRequired,
                IsApprovalRequired = cardTask.IsApprovalRequired,
                IsActive = cardTask.IsActive,
                CreatedAt = cardTask.CreatedAt
            };
        }

        public async Task<CardTaskResponseDto> DeleteCardTask(int cardTaskId)
        {
            var cardTask = await _context.CardTasks.FirstOrDefaultAsync(x => x.CardTaskId == cardTaskId && !x.IsDeleted);

            if (cardTask == null)
                throw new Exception("Card Task not found.");

            cardTask.IsDeleted = true;
            cardTask.IsActive = false;
            cardTask.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new CardTaskResponseDto()
            {
                CardTaskId = cardTask.CardTaskId,
                CardId = cardTask.CardId,
                Title = cardTask.Title,
                Description = cardTask.Description,
                SequenceNo = cardTask.SequenceNo,
                EstimatedMinutes = cardTask.EstimatedMinutes,
                IsMandatory = cardTask.IsMandatory,
                IsSubmissionRequired = cardTask.IsSubmissionRequired,
                IsApprovalRequired = cardTask.IsApprovalRequired,
                IsActive = cardTask.IsActive,
                CreatedAt = cardTask.CreatedAt
            };
        }

        public async Task<List<CardTaskResponseDto>> GetAllCardTasks()
        {
            var cardTasks = await _context.CardTasks.Where(x => !x.IsDeleted).OrderBy(x => x.SequenceNo).ToListAsync();

            List<CardTaskResponseDto> response = new();

            foreach (var item in cardTasks)
            {
                response.Add(new CardTaskResponseDto()
                {
                    CardTaskId = item.CardTaskId,
                    CardId = item.CardId,
                    Title = item.Title,
                    Description = item.Description,
                    SequenceNo = item.SequenceNo,
                    EstimatedMinutes = item.EstimatedMinutes,
                    IsMandatory = item.IsMandatory,
                    IsSubmissionRequired = item.IsSubmissionRequired,
                    IsApprovalRequired = item.IsApprovalRequired,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;
        }

        public async Task<CardTaskResponseDto> GetCardTask(int cardTaskId)
        {
            var cardTask = await _context.CardTasks
        .FirstOrDefaultAsync(x => x.CardTaskId == cardTaskId && !x.IsDeleted);

            if (cardTask == null)
                throw new Exception("Card Task not found.");

            return new CardTaskResponseDto()
            {
                CardTaskId = cardTask.CardTaskId,
                CardId = cardTask.CardId,
                Title = cardTask.Title,
                Description = cardTask.Description,
                SequenceNo = cardTask.SequenceNo,
                EstimatedMinutes = cardTask.EstimatedMinutes,
                IsMandatory = cardTask.IsMandatory,
                IsSubmissionRequired = cardTask.IsSubmissionRequired,
                IsApprovalRequired = cardTask.IsApprovalRequired,
                IsActive = cardTask.IsActive,
                CreatedAt = cardTask.CreatedAt
            };
        }

        public async Task<CardTaskResponseDto> UpdateCardTask(CardTaskUpdateDto dto)
        {
            var cardTask = await _context.CardTasks
       .FirstOrDefaultAsync(x => x.CardTaskId == dto.CardTaskId && !x.IsDeleted);

            if (cardTask == null)
                throw new Exception("Card Task not found.");

            cardTask.CardId = dto.CardId;
            cardTask.Title = dto.Title;
            cardTask.Description = dto.Description;
            cardTask.SequenceNo = dto.SequenceNo;
            cardTask.EstimatedMinutes = dto.EstimatedMinutes;
            cardTask.IsMandatory = dto.IsMandatory;
            cardTask.IsSubmissionRequired = dto.IsSubmissionRequired;
            cardTask.IsApprovalRequired = dto.IsApprovalRequired;
            cardTask.IsActive = dto.IsActive;
            cardTask.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new CardTaskResponseDto()
            {
                CardTaskId = cardTask.CardTaskId,
                CardId = cardTask.CardId,
                Title = cardTask.Title,
                Description = cardTask.Description,
                SequenceNo = cardTask.SequenceNo,
                EstimatedMinutes = cardTask.EstimatedMinutes,
                IsMandatory = cardTask.IsMandatory,
                IsSubmissionRequired = cardTask.IsSubmissionRequired,
                IsApprovalRequired = cardTask.IsApprovalRequired,
                IsActive = cardTask.IsActive,
                CreatedAt = cardTask.CreatedAt
            };
        }
    }
}
