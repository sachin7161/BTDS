using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class GateService : IGateService
    {
        private readonly BtdsdbContext _context;
        private readonly ILogger<GateService> _logger;
        public GateService(BtdsdbContext context, ILogger<GateService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GateResponseDto> AddGate(GateCreateDto dto)
        {
            _logger.LogInformation("Gate creation started.");

            
            var isNameExist = await _context.Gates
                .AnyAsync(x => x.Name == dto.Name && !x.IsDeleted);

            if (isNameExist)
            {
                throw new Exception("Gate Name already exists.");
            }

            // Generate Gate Code
            var lastGate = await _context.Gates
                .OrderByDescending(x => x.GateId)
                .FirstOrDefaultAsync();

            string gateCode;

            if (lastGate == null)
            {
                gateCode = "G001";
            }
            else
            {
                int nextNumber = lastGate.GateId + 1;
                gateCode = $"G{nextNumber:D3}";
            }

            Gate gate = new Gate()
            {
                Code = gateCode,
                Name = dto.Name,
                Description = dto.Description,
                SequenceNo = dto.SequenceNo,
                DurationWeeks = dto.DurationWeeks,
                TotalCards = dto.TotalCards,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Gate created successfully.");

            return new GateResponseDto
            {
                GateId = gate.GateId,
                Code = gate.Code,
                Name = gate.Name,
                Description = gate.Description,
                SequenceNo = gate.SequenceNo,
                DurationWeeks = gate.DurationWeeks,
                TotalCards = gate.TotalCards,
                IsActive = gate.IsActive,
                CreatedAt = gate.CreatedAt
            };
        }

        public async Task<GateResponseDto> DeleteGate(int gateId)
        {
            _logger.LogInformation("Gate delete started.");

            var gate = await _context.Gates
                .FirstOrDefaultAsync(x => x.GateId == gateId && !x.IsDeleted);

            if (gate == null)
            {
                throw new Exception("Gate not found.");
            }

            // Soft Delete
            gate.IsDeleted = true;
            gate.IsActive = false;
            gate.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Gate deleted successfully.");

            return new GateResponseDto()
            {
                GateId = gate.GateId,
                Code = gate.Code,
                Name = gate.Name,
                Description = gate.Description,
                SequenceNo = gate.SequenceNo,
                DurationWeeks = gate.DurationWeeks,
                TotalCards = gate.TotalCards,
                IsActive = gate.IsActive,
                CreatedAt = gate.CreatedAt
            };
        }

        public async Task<List<GateResponseDto>> GetAllGates()
        {
            _logger.LogInformation("Fetching all gates.");

            var gates = await _context.Gates
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.SequenceNo)
                .ToListAsync();

            if (gates.Count == 0)
            {
                throw new Exception("No gates found.");
            }

            List<GateResponseDto> response = new List<GateResponseDto>();

            foreach (var gate in gates)
            {
                response.Add(new GateResponseDto
                {
                    GateId = gate.GateId,
                    Code = gate.Code,
                    Name = gate.Name,
                    Description = gate.Description,
                    SequenceNo = gate.SequenceNo,
                    DurationWeeks = gate.DurationWeeks,
                    TotalCards = gate.TotalCards,
                    IsActive = gate.IsActive,
                    CreatedAt = gate.CreatedAt
                });
            }

            _logger.LogInformation("All gates fetched successfully.");

            return response;
        }

        public async Task<GateResponseDto> GetGate(int gateId)
        {
            _logger.LogInformation("Fetching Gate Details.");

            var gate = await _context.Gates
                .FirstOrDefaultAsync(x => x.GateId == gateId && !x.IsDeleted);

            if (gate == null)
            {
                throw new Exception("Gate not found.");
            }

            _logger.LogInformation("Gate fetched successfully.");

            GateResponseDto response = new GateResponseDto()
            {
                GateId = gate.GateId,
                Code = gate.Code,
                Name = gate.Name,
                Description = gate.Description,
                SequenceNo = gate.SequenceNo,
                DurationWeeks = gate.DurationWeeks,
                TotalCards = gate.TotalCards,
                IsActive = gate.IsActive,
                CreatedAt = gate.CreatedAt
            };

            return response;
        }

        public async Task<GateResponseDto> UpdateGate(GateUpdateDto dto)
        {
            _logger.LogInformation("Gate update started.");

            var gate = await _context.Gates
                .FirstOrDefaultAsync(x => x.GateId == dto.GateId && !x.IsDeleted);

            if (gate == null)
            {
                throw new Exception("Gate not found.");
            }

            // Check Duplicate Name
            var isNameExist = await _context.Gates.AnyAsync(x =>
                x.Name == dto.Name &&
                x.GateId != dto.GateId &&
                !x.IsDeleted);

            if (isNameExist)
            {
                throw new Exception("Gate Name already exists.");
            }

           
            

           // gate.Code = dto.Code;
            gate.Name = dto.Name;
            gate.Description = dto.Description;
            gate.SequenceNo = dto.SequenceNo;
            gate.DurationWeeks = dto.DurationWeeks;
            gate.TotalCards = dto.TotalCards;
            gate.IsActive = dto.IsActive;
            gate.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Gate updated successfully.");

            return new GateResponseDto()
            {
                GateId = gate.GateId,
                Code = gate.Code,
                Name = gate.Name,
                Description = gate.Description,
                SequenceNo = gate.SequenceNo,
                DurationWeeks = gate.DurationWeeks,
                TotalCards = gate.TotalCards,
                IsActive = gate.IsActive,
                CreatedAt = gate.CreatedAt
            };
        }
    }
}
