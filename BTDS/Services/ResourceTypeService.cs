using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class ResourceTypeService : IResourceTypeService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<ResourceTypeService> _logger;
        public ResourceTypeService(BtdsdbContext context, ILogger<ResourceTypeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResourceTypeResponseDto> AddResourceType(ResourceTypeCreateDto dto)
        {
            _logger.LogInformation("Resource Type creation started.");

            var isExist = await _context.ResourceTypes
                .AnyAsync(x => x.Name == dto.Name && !x.IsDeleted);

            if (isExist)
                throw new Exception("Resource Type already exists.");

            ResourceType resourceType = new ResourceType()
            {
                Name = dto.Name,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.ResourceTypes.Add(resourceType);
            await _context.SaveChangesAsync();

            return new ResourceTypeResponseDto()
            {
                ResourceTypeId = resourceType.ResourceTypeId,
                Name = resourceType.Name,
                IsActive = resourceType.IsActive,
                CreatedAt = resourceType.CreatedAt
            };
        }

        public async Task<ResourceTypeResponseDto> DeleteResourceType(int resourceTypeId)
        {
            var resourceType = await _context.ResourceTypes
       .FirstOrDefaultAsync(x => x.ResourceTypeId == resourceTypeId && !x.IsDeleted);

            if (resourceType == null)
                throw new Exception("Resource Type not found.");

            resourceType.IsDeleted = true;
            resourceType.IsActive = false;
            resourceType.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ResourceTypeResponseDto()
            {
                ResourceTypeId = resourceType.ResourceTypeId,
                Name = resourceType.Name,
                IsActive = resourceType.IsActive,
                CreatedAt = resourceType.CreatedAt
            };
        }

        public async Task<List<ResourceTypeResponseDto>> GetAllResourceTypes()
        {
            var resourceTypes = await _context.ResourceTypes
       .Where(x => !x.IsDeleted)
       .ToListAsync();

            List<ResourceTypeResponseDto> response = new();

            foreach (var item in resourceTypes)
            {
                response.Add(new ResourceTypeResponseDto()
                {
                    ResourceTypeId = item.ResourceTypeId,
                    Name = item.Name,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return response;
        }

        public async Task<ResourceTypeResponseDto> GetResourceType(int resourceTypeId)
        {
            var resourceType = await _context.ResourceTypes
        .FirstOrDefaultAsync(x => x.ResourceTypeId == resourceTypeId && !x.IsDeleted);

            if (resourceType == null)
                throw new Exception("Resource Type not found.");

            return new ResourceTypeResponseDto()
            {
                ResourceTypeId = resourceType.ResourceTypeId,
                Name = resourceType.Name,
                IsActive = resourceType.IsActive,
                CreatedAt = resourceType.CreatedAt
            };
        }

        public async Task<ResourceTypeResponseDto> UpdateResourceType(ResourceTypeUpdateDto dto)
        {
            var resourceType = await _context.ResourceTypes
       .FirstOrDefaultAsync(x => x.ResourceTypeId == dto.ResourceTypeId && !x.IsDeleted);

            if (resourceType == null)
                throw new Exception("Resource Type not found.");

            var isExist = await _context.ResourceTypes.AnyAsync(x =>
                x.Name == dto.Name &&
                x.ResourceTypeId != dto.ResourceTypeId &&
                !x.IsDeleted);

            if (isExist)
                throw new Exception("Resource Type already exists.");

            resourceType.Name = dto.Name;
            resourceType.IsActive = dto.IsActive;
            resourceType.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ResourceTypeResponseDto()
            {
                ResourceTypeId = resourceType.ResourceTypeId,
                Name = resourceType.Name,
                IsActive = resourceType.IsActive,
                CreatedAt = resourceType.CreatedAt
            };
        }
    }
}
