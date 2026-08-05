using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IResourceTypeService
    {
        Task<List<ResourceTypeResponseDto>> GetAllResourceTypes();

        Task<ResourceTypeResponseDto> GetResourceType(int resourceTypeId);

        Task<ResourceTypeResponseDto> AddResourceType(ResourceTypeCreateDto dto);

        Task<ResourceTypeResponseDto> UpdateResourceType(ResourceTypeUpdateDto dto);

        Task<ResourceTypeResponseDto> DeleteResourceType(int resourceTypeId);
    }
}
