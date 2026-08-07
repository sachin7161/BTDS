using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class ExamAttemptService : IExamAttemptService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<ExamAttemptService> _logger;
        
        public ExamAttemptService(BtdsdbContext context, ILogger<ExamAttemptService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ExamAttemptResponseDto> AddExamAttempt(ExamAttemptCreateDto dto)
        {
            _logger.LogInformation("Exam attempt creation started.");

            ExamAttempt examAttempt = new ExamAttempt()
            {
                UserId = dto.UserId,
                ExamId = dto.ExamId,
                AttemptNo = dto.AttemptNo,
                StartedAt = dto.StartedAt,
                TotalMarks = dto.TotalMarks,
                Status = dto.Status,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };
            _context.ExamAttempts.Add(examAttempt);
            await _context.SaveChangesAsync();

            return new ExamAttemptResponseDto
            {
                AttemptId = examAttempt.AttemptId,
                UserId = examAttempt.UserId,
                ExamId = examAttempt.ExamId,
                AttemptNo = examAttempt.AttemptNo,
                StartedAt = examAttempt.StartedAt,
                TotalMarks = examAttempt.TotalMarks,
                Status = examAttempt.Status,
                CreatedAt = examAttempt.CreatedAt
            };
        }

        public async Task<ExamAttemptResponseDto> DeleteExamAttempt(long attemptId)
        {
            var examAttempt = await _context.ExamAttempts.FirstOrDefaultAsync(x =>x.AttemptId == attemptId && !x.IsDeleted);

            if (examAttempt == null)
            {
                throw new Exception("Exam attempt not found.");
            }

            examAttempt.IsDeleted = true;
            examAttempt.IsActive = false;
            examAttempt.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ExamAttemptResponseDto()
            {
                AttemptId = examAttempt.AttemptId,
                UserId = examAttempt.UserId,
                ExamId = examAttempt.ExamId,
                Status = examAttempt.Status
            };

        }

        public async Task<List<ExamAttemptResponseDto>> GetAllExamAttempts()
        {
            var examAttempts = await _context.ExamAttempts.Where(x => !x.IsDeleted).ToListAsync();

            List<ExamAttemptResponseDto> response = new();

            foreach (var item in examAttempts)
            {
                response.Add(new ExamAttemptResponseDto()
                {
                    AttemptId = item.AttemptId,
                    UserId = item.UserId,
                    ExamId = item.ExamId,
                    AttemptNo = item.AttemptNo,
                    StartedAt = item.StartedAt,
                    SubmittedAt = item.SubmittedAt,
                    ObtainedMarks = item.ObtainedMarks,
                    Percentage = item.Percentage,
                    Result = item.Result,
                    Status = item.Status,
                    CreatedAt = item.CreatedAt
                });
            }
            return response;
        }

        public async Task<ExamAttemptResponseDto> GetExamAttempt(long attemptId)
        {
            var examAttempt =await _context.ExamAttempts.FirstOrDefaultAsync(x =>x.AttemptId == attemptId && !x.IsDeleted);
            if (examAttempt == null)
            {
                throw new Exception("Exam attempt not found.");
            }
            return new ExamAttemptResponseDto()
            {
                AttemptId = examAttempt.AttemptId,
                UserId = examAttempt.UserId,
                ExamId = examAttempt.ExamId,
                AttemptNo = examAttempt.AttemptNo,
                StartedAt = examAttempt.StartedAt,
                SubmittedAt = examAttempt.SubmittedAt,
                TotalMarks = examAttempt.TotalMarks,
                ObtainedMarks = examAttempt.ObtainedMarks,
                Percentage = examAttempt.Percentage,
                Result = examAttempt.Result,
                Status = examAttempt.Status,
                CreatedAt = examAttempt.CreatedAt
            };
        }




        public async Task<ExamAttemptResponseDto> UpdateExamAttempt(ExamAttemptUpdateDto dto)
        {
            var examAttempt = await _context.ExamAttempts.FirstOrDefaultAsync(x =>x.AttemptId == dto.AttemptId &&!x.IsDeleted);

            if (examAttempt == null)
            {
                throw new Exception("Exam attempt not found.");
            }

            examAttempt.UserId = dto.UserId;
            examAttempt.ExamId = dto.ExamId;
            examAttempt.AttemptNo = dto.AttemptNo;
            examAttempt.StartedAt = dto.StartedAt;
            examAttempt.SubmittedAt = dto.SubmittedAt;
            examAttempt.TimeTaken = dto.TimeTaken;
            examAttempt.TotalMarks = dto.TotalMarks;
            examAttempt.ObtainedMarks = dto.ObtainedMarks;
            examAttempt.Percentage = dto.Percentage;
            examAttempt.Result = dto.Result;
            examAttempt.Status = dto.Status;
            examAttempt.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return new ExamAttemptResponseDto()
            {
                AttemptId = examAttempt.AttemptId,
                UserId = examAttempt.UserId,
                ExamId = examAttempt.ExamId,
                Status = examAttempt.Status
            };
        }
    }
}
