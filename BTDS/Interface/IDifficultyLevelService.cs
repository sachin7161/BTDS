using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IDifficultyLevelService
    {
        Task<List<DifficultyLevelResponseDto>> GetAllDifficultyLevels();

        Task<DifficultyLevelResponseDto> GetDifficultyLevel(int difficultyLevelId);

        Task<DifficultyLevelResponseDto> AddDifficultyLevel(DifficultyLevelCreateDto dto);

        Task<DifficultyLevelResponseDto> UpdateDifficultyLevel(DifficultyLevelUpdateDto dto);

        Task<DifficultyLevelResponseDto> DeleteDifficultyLevel(int difficultyLevelId);
    }
}
