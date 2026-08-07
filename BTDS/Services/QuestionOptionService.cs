using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<QuestionOptionService> _logger;

        public QuestionOptionService(BtdsdbContext context, ILogger<QuestionOptionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<QuestionOptionResponseDto> AddQuestionOption(QuestionOptionCreateDto dto)
        {
            _logger.LogInformation("Question option creation started.");

            QuestionOption option = new QuestionOption()
            {
                QuestionId = dto.QuestionId,
                OptionText = dto.OptionText,
                IsCorrect = dto.IsCorrect,
                SequenceNo = dto.SequenceNo,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };
            _context.QuestionOptions.Add(option);

            await _context.SaveChangesAsync();

            return new QuestionOptionResponseDto()
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                OptionText = option.OptionText,
                IsCorrect = option.IsCorrect,
                SequenceNo = option.SequenceNo,
                IsActive = option.IsActive,
                CreatedAt = option.CreatedAt
            };
        }

        public async Task<QuestionOptionResponseDto> DeleteQuestionOption(long optionId)
        {
            var option = await _context.QuestionOptions.FirstOrDefaultAsync(x =>x.OptionId == optionId &&!x.IsDeleted);
            if (option == null)
            {
                throw new Exception("Question option not found.");
            }

            option.IsDeleted = true;
            option.IsActive = false;
            option.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new QuestionOptionResponseDto()
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                OptionText = option.OptionText,
                IsCorrect = option.IsCorrect
            };
        }

        public async Task<List<QuestionOptionResponseDto>> GetAllQuestionOptions()
        {
            var options = await _context.QuestionOptions.Where(x => !x.IsDeleted).ToListAsync();

            List<QuestionOptionResponseDto> response = new();

            foreach (var item in options)
            {
                response.Add(new QuestionOptionResponseDto()
                {
                    OptionId = item.OptionId,
                    QuestionId = item.QuestionId,
                    OptionText = item.OptionText,
                    IsCorrect = item.IsCorrect,
                    SequenceNo = item.SequenceNo,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });

            }
            return response;
        }

        public async Task<QuestionOptionResponseDto> GetQuestionOption(long optionId)
        {
            var option = await _context.QuestionOptions.FirstOrDefaultAsync(x => x.OptionId == optionId &&!x.IsDeleted);

            if (option == null)
            {
                throw new Exception("Question option not found.");
            }

            return new QuestionOptionResponseDto()
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                OptionText = option.OptionText,
                IsCorrect = option.IsCorrect,
                SequenceNo = option.SequenceNo,
                IsActive = option.IsActive,
                CreatedAt = option.CreatedAt
            };

        }

        public async Task<QuestionOptionResponseDto> UpdateQuestionOption(QuestionOptionUpdateDto dto)
        {
            var option = await _context.QuestionOptions.FirstOrDefaultAsync(x =>x.OptionId == dto.OptionId &&!x.IsDeleted);

            if (option == null)
            {
                throw new Exception("Question option not found.");
            }

            option.QuestionId = dto.QuestionId;
            option.OptionText = dto.OptionText;
            option.IsCorrect = dto.IsCorrect;
            option.SequenceNo = dto.SequenceNo;
            option.IsActive = dto.IsActive;
            option.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new QuestionOptionResponseDto()
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                OptionText = option.OptionText,
                IsCorrect = option.IsCorrect,
                SequenceNo = option.SequenceNo,
                IsActive = option.IsActive,
                UpdatedAt = option.UpdatedAt
            };
        }
    }
}
