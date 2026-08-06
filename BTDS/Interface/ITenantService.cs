using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface ITenantService
    {
        Task<List<TenantResponseDto>> GetAllTenants();

        Task<TenantResponseDto> GetTenant(int tenantId);

        Task<TenantResponseDto> AddTenant(TenantCreateDto dto);

        Task<TenantResponseDto> UpdateTenant(TenantUpdateDto dto);

        Task<TenantResponseDto> DeleteTenant(int tenantId);
    }
}
