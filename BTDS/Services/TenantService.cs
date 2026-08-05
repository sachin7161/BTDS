using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class TenantService : ITenantService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<TenantService> _logger;

        public TenantService(BtdsdbContext context, ILogger<TenantService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TenantResponseDto> AddTenant(TenantCreateDto dto)
        {
            _logger.LogInformation("Tenant creation started.");

            var isExist = await _context.Tenants
                .AnyAsync(x => x.TenantCode == dto.TenantCode && !x.IsDeleted);

            if (isExist)
                throw new Exception("Tenant already exists.");

            Tenant tenant = new Tenant()
            {
                TenantCode = dto.TenantCode,
                TenantName = dto.TenantName,
                OrganizationType = dto.OrganizationType,
                Logo = dto.Logo,
                Url = dto.Url,
                Website = dto.Website,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return new TenantResponseDto()
            {
                TenantId = tenant.TenantId,
                TenantCode = tenant.TenantCode,
                TenantName = tenant.TenantName,
                OrganizationType = tenant.OrganizationType,
                Logo = tenant.Logo,
                Url = tenant.Url,
                Website = tenant.Website,
                Email = tenant.Email,
                Phone = tenant.Phone,
                Address = tenant.Address,
                City = tenant.City,
                State = tenant.State,
                PostalCode = tenant.PostalCode,
                IsActive = tenant.IsActive,
                CreatedAt = tenant.CreatedAt
            };
        }

        public async Task<TenantResponseDto> DeleteTenant(int tenantId)
        {
            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && !x.IsDeleted);

            if (tenant == null)
                throw new Exception("Tenant not found.");

            tenant.IsDeleted = true;
            tenant.IsActive = false;
            tenant.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new TenantResponseDto()
            {
                TenantId = tenant.TenantId,
                TenantCode = tenant.TenantCode,
                TenantName = tenant.TenantName,
                IsActive = tenant.IsActive
            };
        }

        public async Task<List<TenantResponseDto>> GetAllTenants()
        {
            var tenants = await _context.Tenants
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            List<TenantResponseDto> response = new();

            foreach (var item in tenants)
            {
                response.Add(new TenantResponseDto()
                {
                    TenantId = item.TenantId,
                    TenantCode = item.TenantCode,
                    TenantName = item.TenantName,
                    OrganizationType = item.OrganizationType,
                    Email = item.Email,
                    Phone = item.Phone,
                    City = item.City,
                    State = item.State,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;
        }

        public async Task<TenantResponseDto> GetTenant(int tenantId)
        {
            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && !x.IsDeleted);

            if (tenant == null)
                throw new Exception("Tenant not found.");

            return new TenantResponseDto()
            {
                TenantId = tenant.TenantId,
                TenantCode = tenant.TenantCode,
                TenantName = tenant.TenantName,
                OrganizationType = tenant.OrganizationType,
                Logo = tenant.Logo,
                Url = tenant.Url,
                Website = tenant.Website,
                Email = tenant.Email,
                Phone = tenant.Phone,
                Address = tenant.Address,
                City = tenant.City,
                State = tenant.State,
                PostalCode = tenant.PostalCode,
                IsActive = tenant.IsActive,
                CreatedAt = tenant.CreatedAt
            };
        }

        public async Task<TenantResponseDto> UpdateTenant(TenantUpdateDto dto)
        {
            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(x => x.TenantId == dto.TenantId && !x.IsDeleted);

            if (tenant == null)
                throw new Exception("Tenant not found.");

            tenant.TenantCode = dto.TenantCode;
            tenant.TenantName = dto.TenantName;
            tenant.OrganizationType = dto.OrganizationType;
            tenant.Logo = dto.Logo;
            tenant.Url = dto.Url;
            tenant.Website = dto.Website;
            tenant.Email = dto.Email;
            tenant.Phone = dto.Phone;
            tenant.Address = dto.Address;
            tenant.City = dto.City;
            tenant.State = dto.State;
            tenant.PostalCode = dto.PostalCode;
            tenant.IsActive = dto.IsActive;
            tenant.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new TenantResponseDto()
            {
                TenantId = tenant.TenantId,
                TenantCode = tenant.TenantCode,
                TenantName = tenant.TenantName,
                IsActive = tenant.IsActive
            };
        }
    }
}
