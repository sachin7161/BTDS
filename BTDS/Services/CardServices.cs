using BTDS.DTOs;
using BTDS.Interface;

using BTDS.Models;
using Microsoft.EntityFrameworkCore;
namespace BTDS.Services
{
    public class CardServices : ICardsService
    {
        private readonly BtdsdbContext _contex;
        private readonly ILogger<CardServices> _logger;

        public CardServices(BtdsdbContext contex, ILogger<CardServices> logger)
        {
            _contex = contex;
            _logger = logger;
        }
        public async Task<CardResponseDto> AddCard(CardCreateDto dto)
        {
            _logger.LogInformation("Add Card Processing");
            Card card = new Card()
            {
                StageId = dto.StageId,
                TechStack = dto.Techstack,
                TaskTitle = dto.Tasktitle,
                LearningTopics = dto.Learningtopic,
                Duration = dto.Duration

            };
            _contex.Cards.Add(card);
            await _contex.SaveChangesAsync();
            _logger.LogInformation("Card create successfully");

            CardResponseDto cardResponse = new CardResponseDto()
            {
                Id = card.Id,
                StageId = card.StageId ?? 0,
                Techstack = card.TechStack,
                Tasktitle = card.TaskTitle,
                Learningtopic = card.LearningTopics,
                Duration = card.Duration ?? 0,
                IsActive = card.IsActive ?? false,
                CreateDate = card.CreatedAt ?? DateTime.MinValue,
  
            }; 
            return cardResponse;
            

        }

        public async Task<CardResponseDto> DeleteCard(int cardid)
        {
            _logger.LogInformation("Card Deleting successfylly");
            var card = await _contex.Cards.FindAsync(cardid);
            if(card == null)
            {
                throw new Exception("Not Found Card Details");
            }

            card.IsActive= false;
            card.UpdatedAt = DateTime.Now;
            await _contex.SaveChangesAsync();
            _logger.LogInformation("Card delete successfully");

           

            CardResponseDto cardResponse = new CardResponseDto()
            {
                Id = card.Id,
                StageId = card.StageId ?? 0,
                Techstack = card.TechStack,
                Tasktitle = card.TaskTitle,
                Learningtopic = card.LearningTopics,
                Duration = card.Duration ?? 0,
                IsActive = card.IsActive ?? false,
                CreateDate = card.CreatedAt ?? DateTime.MinValue,
            };
            return cardResponse;
             
        }

        public async Task<List<CardResponseDto>> GetAllCards()
        {
            _logger.LogInformation(" start All card Fetch");
            var card = await _contex.Cards.ToListAsync();
            _logger.LogInformation("All card fetch successfully");
            List<CardResponseDto>responses=new List<CardResponseDto>();   

            if (card == null)
            {
                throw new Exception("Cards Not Found");
            }

            foreach(var c in card)
            {
                CardResponseDto cardResponse = new CardResponseDto()
                {
                    Id = c.Id,
                    StageId = c.StageId ?? 0,
                    Techstack = c.TechStack,
                    Tasktitle = c.TaskTitle,
                    Learningtopic = c.LearningTopics,
                    Duration = c.Duration ?? 0,
                    IsActive = c.IsActive ?? false,
                    CreateDate = c.CreatedAt ?? DateTime.MinValue,
                };
                responses.Add(cardResponse);

            }
            return responses;
        }

        public async Task<CardResponseDto> GetCard(int CardId)
        {
            _logger.LogInformation("Start Fetching Card");
            var card = await _contex.Cards.FindAsync(CardId);
                if(card == null)
                {
                    throw new Exception("Card Not Found");
                }
            _logger.LogInformation("Card fetch successfylly");
            CardResponseDto response = new CardResponseDto()
            {
                Id = card.Id,
                StageId = card.StageId ?? 0,
                Techstack = card.TechStack,
                Tasktitle = card.TaskTitle,
                Learningtopic = card.LearningTopics,
                Duration = card.Duration ?? 0,
                IsActive = card.IsActive ?? false,
                CreateDate = card.CreatedAt ?? DateTime.MinValue,
            };
            return response;
        }

        public async Task<CardResponseDto> UpdateCard(CardUpdateDto dto)
        {
            _logger.LogInformation("update card processing");
           var card=await _contex.Cards.FirstOrDefaultAsync(e=>e.Id==dto.Id);
           if(card == null)
            {
                throw new Exception("Recoard Not Found");
            }
           card.StageId=dto.StageId;
            card.TechStack = dto.Techstack;
            card.TaskTitle = dto.Tasktitle;
            card.LearningTopics = dto.Learningtopic;
            card.Duration=dto.Duration;
            card.UpdatedAt = DateTime.Now;
            await _contex.SaveChangesAsync();
            _logger.LogInformation("Update card successfully");
            CardResponseDto response = new CardResponseDto()
            {
                Id = card.Id,
                StageId = card.StageId ?? 0,
                Techstack = card.TechStack,
                Tasktitle = card.TaskTitle,
                Learningtopic = card.LearningTopics,
                Duration = card.Duration ?? 0,
                IsActive = card.IsActive ?? false,
                CreateDate = card.CreatedAt ?? DateTime.MinValue,
            };
            return response;

           
        }
    }
}
