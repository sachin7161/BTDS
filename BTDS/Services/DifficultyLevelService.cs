using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;
namespace BTDS.Services
{
    public class DifficultyLevelService : IDifficultyLevelService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<DifficultyLevelService> _logger;
        public DifficultyLevelService(BtdsdbContext context, ILogger<DifficultyLevelService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DifficultyLevelResponseDto> AddDifficultyLevel(DifficultyLevelCreateDto dto)
        {
            _logger.LogInformation("Difficulty Level creation started.");

            var isExist = await _context.DifficultyLevels
                .AnyAsync(x => x.Name == dto.Name && !x.IsDeleted);

            if (isExist)
                throw new Exception("Difficulty Level already exists.");

            DifficultyLevel difficulty = new DifficultyLevel()
            {
                Name = dto.Name,
                SequenceNo = dto.SequenceNo,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.DifficultyLevels.Add(difficulty);
            await _context.SaveChangesAsync();

            return new DifficultyLevelResponseDto()
            {
                DifficultyLevelId = difficulty.DifficultyLevelId,
                Name = difficulty.Name,
                SequenceNo = difficulty.SequenceNo,
                IsActive = difficulty.IsActive,
                CreatedAt = difficulty.CreatedAt
            };
        }

        public async Task<DifficultyLevelResponseDto> DeleteDifficultyLevel(int difficultyLevelId)
        {
            var level = await _context.DifficultyLevels
       .FirstOrDefaultAsync(x => x.DifficultyLevelId == difficultyLevelId && !x.IsDeleted);

            if (level == null)
                throw new Exception("Difficulty Level not found.");

            level.IsDeleted = true;
            level.IsActive = false;
            level.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new DifficultyLevelResponseDto()
            {
                DifficultyLevelId = level.DifficultyLevelId,
                Name = level.Name,
                SequenceNo = level.SequenceNo,
                IsActive = level.IsActive,
                CreatedAt = level.CreatedAt
            };
        }
        public async Task<List<DifficultyLevelResponseDto>> GetAllDifficultyLevels()
        {
            var levels = await _context.DifficultyLevels
       .Where(x => !x.IsDeleted)
       .OrderBy(x => x.SequenceNo)
       .ToListAsync();

            List<DifficultyLevelResponseDto> response = new();

            foreach (var item in levels)
            {
                response.Add(new DifficultyLevelResponseDto()
                {
                    DifficultyLevelId = item.DifficultyLevelId,
                    Name = item.Name,
                    SequenceNo = item.SequenceNo,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;
        }
        

        public async Task<DifficultyLevelResponseDto> GetDifficultyLevel(int difficultyLevelId)
        {
            var level = await _context.DifficultyLevels
       .FirstOrDefaultAsync(x => x.DifficultyLevelId == difficultyLevelId && !x.IsDeleted);

            if (level == null)
                throw new Exception("Difficulty Level not found.");

            return new DifficultyLevelResponseDto()
            {
                DifficultyLevelId = level.DifficultyLevelId,
                Name = level.Name,
                SequenceNo = level.SequenceNo,
                IsActive = level.IsActive,
                CreatedAt = level.CreatedAt
            };
        }

        public async Task<DifficultyLevelResponseDto> UpdateDifficultyLevel(DifficultyLevelUpdateDto dto)
        {
            var level = await _context.DifficultyLevels
        .FirstOrDefaultAsync(x => x.DifficultyLevelId == dto.DifficultyLevelId && !x.IsDeleted);

            if (level == null)
                throw new Exception("Difficulty Level not found.");

            var isExist = await _context.DifficultyLevels.AnyAsync(x =>
                x.Name == dto.Name &&
                x.DifficultyLevelId != dto.DifficultyLevelId &&
                !x.IsDeleted);

            if (isExist)
                throw new Exception("Difficulty Level already exists.");

            level.Name = dto.Name;
            level.SequenceNo = dto.SequenceNo;
            level.IsActive = dto.IsActive;
            level.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new DifficultyLevelResponseDto()
            {
                DifficultyLevelId = level.DifficultyLevelId,
                Name = level.Name,
                SequenceNo = level.SequenceNo,
                IsActive = level.IsActive,
                CreatedAt = level.CreatedAt
            };
        }
    }
}
