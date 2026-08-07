using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<QuestionService> _logger;

        public QuestionService(BtdsdbContext context, ILogger<QuestionService> logger)
        {
            _context = context; 
            _logger = logger;
        }

        public async Task<QuestionResponseDto> AddQuestion(QuestionCreateDto dto)
        {
            _logger.LogInformation("Question creation started.");

            Question question = new Question()
            {
                ExamId = dto.ExamId,
                QuestionText = dto.QuestionText,
                QuestionType = dto.QuestionType,
                Marks = dto.Marks,
                Explanation = dto.Explanation,
                DifficultyLevel = dto.DifficultyLevel,
                SequenceNo = dto.SequenceNo,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.Questions.Add(question);

            await _context.SaveChangesAsync();

            return new QuestionResponseDto()
            {
                QuestionId = question.QuestionId,
                ExamId = question.ExamId,
                QuestionText = question.QuestionText,
                QuestionType = question.QuestionType,
                Marks = question.Marks,
                Explanation = question.Explanation,
                DifficultyLevel = question.DifficultyLevel,
                SequenceNo = question.SequenceNo,
                IsActive = question.IsActive,
                CreatedAt = question.CreatedAt
            };
        }

        public async Task<QuestionResponseDto> DeleteQuestion(long questionId)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x =>x.QuestionId == questionId &&!x.IsDeleted);

            if (question == null)
            {
                throw new Exception("Question not found.");
            }

            question.IsDeleted = true;
            question.IsActive = false;
            question.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new QuestionResponseDto()
            {
                QuestionId = question.QuestionId,
                ExamId = question.ExamId,
                QuestionText = question.QuestionText,
                IsActive = question.IsActive
            };
        }

        public async Task<List<QuestionResponseDto>> GetAllQuestions()
        {
            var questions = await _context.Questions.Where(x=> !x.IsDeleted).ToListAsync();

            List<QuestionResponseDto> response = new();

            foreach (var item in questions)
            {
                response.Add(new QuestionResponseDto()
                {
                    QuestionId = item.QuestionId,
                    ExamId = item.ExamId,
                    QuestionText = item.QuestionText,
                    QuestionType = item.QuestionType,
                    Marks = item.Marks,
                    Explanation = item.Explanation,
                    DifficultyLevel = item.DifficultyLevel,
                    SequenceNo = item.SequenceNo,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;

        }

        public async Task<QuestionResponseDto> GetQuestion(long questionId)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x =>x.QuestionId == questionId &&!x.IsDeleted);

            if (question == null)
            {
                throw new Exception("Question not found.");
            }

            return new QuestionResponseDto()
            {
                QuestionId = question.QuestionId,
                ExamId = question.ExamId,
                QuestionText = question.QuestionText,
                QuestionType = question.QuestionType,
                Marks = question.Marks,
                Explanation = question.Explanation,
                DifficultyLevel = question.DifficultyLevel,
                SequenceNo = question.SequenceNo,
                IsActive = question.IsActive,
                CreatedAt = question.CreatedAt
            };
        }

        public async Task<QuestionResponseDto> UpdateQuestion(QuestionUpdateDto dto)
        {
            var question =await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == dto.QuestionId && !x.IsDeleted);

            if(question == null)
            {
                throw new Exception("Question Not Found.");
            }

            question.ExamId = dto.ExamId;
            question.QuestionText = dto.QuestionText;
            question.QuestionType = dto.QuestionType;
            question.Marks = dto.Marks;
            question.Explanation = dto.Explanation;
            question.DifficultyLevel = dto.DifficultyLevel;
            question.SequenceNo = dto.SequenceNo;
            question.IsActive = dto.IsActive;
            question.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new QuestionResponseDto()
            {
                QuestionId = dto.QuestionId,
                ExamId = question.ExamId,
                QuestionText = question.QuestionText,
                QuestionType = question.QuestionType,
                Marks = question.Marks,
                Explanation = question.Explanation,
                DifficultyLevel = question.DifficultyLevel,
                SequenceNo = question.SequenceNo,
                IsActive = question.IsActive,
                UpdatedAt = question.UpdatedAt
            };
        }
    }
}
