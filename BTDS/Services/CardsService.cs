using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class CardsService : ICardsService
    {
        private readonly BtdsdbContext _contex;
            private readonly ILogger<CardsService> _logger;
        public CardsService(BtdsdbContext context, ILogger<CardsService> logger)
        {
            _contex = context;
            _logger=logger;
        }
        public async Task<CardResponseDto> AddCard(CardCreateDto dto)
        {
            _logger.LogInformation("Creating new card");
            var lastCard = await _contex.Cards.OrderByDescending(x => x.Code).FirstOrDefaultAsync();

            string code;

            if (lastCard == null)
            {
                code = "C001";
            }
            else
            {
                int number = int.Parse(lastCard.Code.Substring(1));
                code = $"C{number + 1:D3}";
            }

            Card card = new Card
            {
                ModuleId = dto.ModuleId,
                CardTypeId = dto.CardTypeId,
                DifficultyLevelId = dto.DifficultyLevelId,
                Code = code,
                Title = dto.Title,
                LearningObjective = dto.LearningObjective,
                Description = dto.Description,
                EstimatedMinutes = dto.EstimatedMinutes,
                SequenceNo = dto.SequenceNo,
                PassingMarks = dto.PassingMarks,
                MaxMarks = dto.MaxMarks,
                IsMandatory = dto.IsMandatory,
                AllowRetake = dto.AllowRetake,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _contex.Cards.Add(card);
            await _contex.SaveChangesAsync();

            _logger.LogInformation("Card created successfully");

            return new CardResponseDto
            {
                CardsId = card.CardsId,
                ModuleId = card.ModuleId,
                CardTypeId = card.CardTypeId,
                DifficultyLevelId = card.DifficultyLevelId,
                Code = card.Code,
                Title = card.Title,
                LearningObjective = card.LearningObjective,
                Description = card.Description,
                EstimatedMinutes = card.EstimatedMinutes,
                SequenceNo = card.SequenceNo,
                PassingMarks = card.PassingMarks,
                MaxMarks = card.MaxMarks,
                IsMandatory = card.IsMandatory,
                AllowRetake = card.AllowRetake,
                IsActive = card.IsActive,
                CreatedAt = card.CreatedAt
            };
        }

        public async Task<CardResponseDto> DeleteCard(int cardId)
        {
            _logger.LogInformation("Deleting card");

            var card = await _contex.Cards
                .FirstOrDefaultAsync(x => x.CardsId == cardId);

            if (card == null)
                throw new Exception("Card not found.");

            card.IsDeleted = true;
            card.IsActive = false;
            card.DeletedAt = DateTime.Now;

            await _contex.SaveChangesAsync();

            _logger.LogInformation("Card deleted successfully");

            return new CardResponseDto
            {
                CardsId = card.CardsId,
                ModuleId = card.ModuleId,
                CardTypeId = card.CardTypeId,
                DifficultyLevelId = card.DifficultyLevelId,
                Code = card.Code,
                Title = card.Title,
                LearningObjective = card.LearningObjective,
                Description = card.Description,
                EstimatedMinutes = card.EstimatedMinutes,
                SequenceNo = card.SequenceNo,
                PassingMarks = card.PassingMarks,
                MaxMarks = card.MaxMarks,
                IsMandatory = card.IsMandatory,
                AllowRetake = card.AllowRetake,
                IsActive = card.IsActive,
                CreatedAt = card.CreatedAt
            };
        }

        public async Task<List<CardResponseDto>> GetAllCards()
        {
            _logger.LogInformation("Fetching all cards");

            var cards = await _contex.Cards
                .Where(x => !x.IsDeleted).ToListAsync();

            return cards.Select(card => new CardResponseDto
            {
                CardsId = card.CardsId,
                ModuleId = card.ModuleId,
                CardTypeId = card.CardTypeId,
                DifficultyLevelId = card.DifficultyLevelId,
                Code = card.Code,
                Title = card.Title,
                LearningObjective = card.LearningObjective,
                Description = card.Description,
                EstimatedMinutes = card.EstimatedMinutes,
                SequenceNo = card.SequenceNo,
                PassingMarks = card.PassingMarks,
                MaxMarks = card.MaxMarks,
                IsMandatory = card.IsMandatory,
                AllowRetake = card.AllowRetake,
                IsActive = card.IsActive,
                CreatedAt = card.CreatedAt
            }).ToList();
        }

        public async Task<CardResponseDto> GetCard(int cardId)
        {
            _logger.LogInformation("Fetching card");

            var card = await _contex.Cards
                .FirstOrDefaultAsync(x => x.CardsId == cardId && !x.IsDeleted);

            if (card == null)
                throw new Exception("Card not found.");

            return new CardResponseDto
            {
                CardsId = card.CardsId,
                ModuleId = card.ModuleId,
                CardTypeId = card.CardTypeId,
                DifficultyLevelId = card.DifficultyLevelId,
                Code = card.Code,
                Title = card.Title,
                LearningObjective = card.LearningObjective,
                Description = card.Description,
                EstimatedMinutes = card.EstimatedMinutes,
                SequenceNo = card.SequenceNo,
                PassingMarks = card.PassingMarks,
                MaxMarks = card.MaxMarks,
                IsMandatory = card.IsMandatory,
                AllowRetake = card.AllowRetake,
                IsActive = card.IsActive,
                CreatedAt = card.CreatedAt
            };
        }

        public async Task<CardResponseDto> UpdateCard(CardUpdateDto dto)
        {
            _logger.LogInformation("Updating card");

            var card = await _contex.Cards
                .FirstOrDefaultAsync(x => x.CardsId == dto.CardsId);

            if (card == null)
                throw new Exception("Card not found.");

            card.ModuleId = dto.ModuleId;
            card.CardTypeId = dto.CardTypeId;
            card.DifficultyLevelId = dto.DifficultyLevelId;
            card.Code = dto.Code;
            card.Title = dto.Title;
            card.LearningObjective = dto.LearningObjective;
            card.Description = dto.Description;
            card.EstimatedMinutes = dto.EstimatedMinutes;
            card.SequenceNo = dto.SequenceNo;
            card.PassingMarks = dto.PassingMarks;
            card.MaxMarks = dto.MaxMarks;
            card.IsMandatory = dto.IsMandatory;
            card.AllowRetake = dto.AllowRetake;
            card.IsActive = dto.IsActive;
            card.UpdatedAt = DateTime.Now;

            await _contex.SaveChangesAsync();

            _logger.LogInformation("Card updated successfully");

            return new CardResponseDto
            {
                CardsId = card.CardsId,
                ModuleId = card.ModuleId,
                CardTypeId = card.CardTypeId,
                DifficultyLevelId = card.DifficultyLevelId,
              //  Code = card.Code,
                Title = card.Title,
                LearningObjective = card.LearningObjective,
                Description = card.Description,
                EstimatedMinutes = card.EstimatedMinutes,
                SequenceNo = card.SequenceNo,
                PassingMarks = card.PassingMarks,
                MaxMarks = card.MaxMarks,
                IsMandatory = card.IsMandatory,
                AllowRetake = card.AllowRetake,
                IsActive = card.IsActive,
                CreatedAt = card.CreatedAt
            };
        }
    }
}
