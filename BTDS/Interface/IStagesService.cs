using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IStagesService
    {
        Task<List<StageResponseDto>> GetAllStage();
        Task<StageResponseDto>GetStage(int stageId);
        Task<StageResponseDto> AddStage(StageCreateDto dto);
        Task<StageResponseDto> UpdateStage(StageUpdateDto dto);
        Task<string>DeleteStage(int stageId);
    }
}
