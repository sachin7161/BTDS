using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IModuleService
    {
        Task<List<ModuleResponseDto>> GetAllModules();

        Task<ModuleResponseDto> GetModule(int moduleId);

        Task<ModuleResponseDto> AddModule(ModuleCreateDto dto);

        Task<ModuleResponseDto> UpdateModule(ModuleUpdateDto dto);

        Task<ModuleResponseDto> DeleteModule(int moduleId);

    }
}
