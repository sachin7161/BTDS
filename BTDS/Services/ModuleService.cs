using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;
namespace BTDS.Services
{
    public class ModuleService : IModuleService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<ModuleService> _logger;
        public ModuleService(BtdsdbContext context, ILogger<ModuleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ModuleResponseDto> AddModule(ModuleCreateDto dto)
        {
            _logger.LogInformation("Module creation started.");

            // Check Gate Exists
            var gate = await _context.Gates.FindAsync(dto.GateId);

            if (gate == null)
            {
                throw new Exception("Gate not found.");
            }

            // Get Last Module Code for Same Gate
            var lastModule = await _context.Modules
                .Where(x => x.GateId == dto.GateId)
                .OrderByDescending(x => x.ModuleId)
                .FirstOrDefaultAsync();

            string moduleCode;

            if (lastModule == null)
            {
                moduleCode = "M001";
            }
            else
            {
                int nextNumber = lastModule.ModuleId + 1;
                moduleCode = $"M{nextNumber:D3}";
            }

            Module module = new Module()
            {
                GateId = dto.GateId,
                Code = moduleCode,
                Name = dto.Name,
                Description = dto.Description,
                SequenceNo = dto.SequenceNo,
                EstimatedHours = dto.EstimatedHours,
                IsMandatory = dto.IsMandatory,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Module created successfully.");

            return new ModuleResponseDto
            {
                ModuleId = module.ModuleId,
                GateId = module.GateId,
                Code = module.Code,
                Name = module.Name,
                Description = module.Description,
                SequenceNo = module.SequenceNo,
                EstimatedHours = module.EstimatedHours,
                IsMandatory = module.IsMandatory,
                IsActive = module.IsActive,
                CreatedAt = module.CreatedAt
            };
        }

        public async Task<ModuleResponseDto> DeleteModule(int moduleId)
        {
            var module = await _context.Modules
       .FirstOrDefaultAsync(x => x.ModuleId == moduleId && !x.IsDeleted);

            if (module == null)
                throw new Exception("Module not found.");

            module.IsDeleted = true;
            module.IsActive = false;
            module.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ModuleResponseDto
            {
                ModuleId = module.ModuleId,
                GateId = module.GateId,
                Code = module.Code,
                Name = module.Name,
                Description = module.Description,
                SequenceNo = module.SequenceNo,
                EstimatedHours = module.EstimatedHours,
                IsMandatory = module.IsMandatory,
                IsActive = module.IsActive,
                CreatedAt = module.CreatedAt
            };
        }

        public async Task<List<ModuleResponseDto>> GetAllModules()
        {

            var modules = await _context.Modules
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.SequenceNo)
                .ToListAsync();

            List<ModuleResponseDto> response = new();

            foreach (var module in modules)
            {
                response.Add(new ModuleResponseDto
                {
                    ModuleId = module.ModuleId,
                    GateId = module.GateId,
                    Code = module.Code,
                    Name = module.Name,
                    Description = module.Description,
                    SequenceNo = module.SequenceNo,
                    EstimatedHours = module.EstimatedHours,
                    IsMandatory = module.IsMandatory,
                    IsActive = module.IsActive,
                    CreatedAt = module.CreatedAt
                });
            }

            return response;
        }

        public async Task<ModuleResponseDto> GetModule(int moduleId)
        {
            var module = await _context.Modules
        .FirstOrDefaultAsync(x => x.ModuleId == moduleId && !x.IsDeleted);

            if (module == null)
                throw new Exception("Module not found.");

            return new ModuleResponseDto
            {
                ModuleId = module.ModuleId,
                GateId = module.GateId,
                Code = module.Code,
                Name = module.Name,
                Description = module.Description,
                SequenceNo = module.SequenceNo,
                EstimatedHours = module.EstimatedHours,
                IsMandatory = module.IsMandatory,
                IsActive = module.IsActive,
                CreatedAt = module.CreatedAt
            };
        }

        public async Task<ModuleResponseDto> UpdateModule(ModuleUpdateDto dto)
        {
            var module = await _context.Modules
        .FirstOrDefaultAsync(x => x.ModuleId == dto.ModuleId && !x.IsDeleted);

            if (module == null)
                throw new Exception("Module not found.");

            var isExist = await _context.Modules.AnyAsync(x =>
                x.GateId == dto.GateId &&
                x.Code == dto.Code &&
                x.ModuleId != dto.ModuleId &&
                !x.IsDeleted);

            if (isExist)
                throw new Exception("Module Code already exists.");

            module.GateId = dto.GateId;
            module.Code = dto.Code;
            module.Name = dto.Name;
            module.Description = dto.Description;
            module.SequenceNo = dto.SequenceNo;
            module.EstimatedHours = dto.EstimatedHours;
            module.IsMandatory = dto.IsMandatory;
            module.IsActive = dto.IsActive;
            module.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ModuleResponseDto
            {
                ModuleId = module.ModuleId,
                GateId = module.GateId,
                Code = module.Code,
                Name = module.Name,
                Description = module.Description,
                SequenceNo = module.SequenceNo,
                EstimatedHours = module.EstimatedHours,
                IsMandatory = module.IsMandatory,
                IsActive = module.IsActive,
                CreatedAt = module.CreatedAt
            };
        }
    }
}
