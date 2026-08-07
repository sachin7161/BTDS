using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class ExamInstrictionService : IExamInstructionService
    {
        private readonly BtdsdbContext _Context;
        private readonly ILogger<ExamInstrictionService> _logger;

        public ExamInstrictionService(BtdsdbContext dbContext, ILogger<ExamInstrictionService> logger)  
        {
            _Context = dbContext;
            _logger = logger;
        }

        public async Task<ExamInstructionResponseDto> AddExamInstruction(ExamInstructionCreateDto dto)
        {
            _logger.LogInformation("Exam instruction creation started");

            ExamInstruction examInstruction = new ExamInstruction()
            {
                ExamId = dto.ExamId,
                Instruction = dto.Instruction,
                SequenceNo = dto.SequenceNo,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now
            };
            _Context.ExamInstructions.Add(examInstruction);
            await _Context.SaveChangesAsync();
            return new ExamInstructionResponseDto
            {
                InstructionId = examInstruction.InstructionId,
                ExamId = examInstruction.ExamId,
                Instruction = examInstruction.Instruction,
                SequenceNo = examInstruction.SequenceNo,
                IsActive = examInstruction.IsActive,
                CreatedAt = examInstruction.CreatedAt
            };
        }

        public async Task<ExamInstructionResponseDto> DeleteExamInstruction(long instructionId)
        {
            var examInstruction = await _Context.ExamInstructions.FirstOrDefaultAsync(x => x.InstructionId == instructionId && !x.IsDeleted);
            if (examInstruction == null)
            { 
                throw new Exception("Exam instruction not found."); 
            }
            examInstruction.IsDeleted = true; 
            examInstruction.IsActive = false; 
            examInstruction.DeletedAt = DateTime.Now; 
            await _Context.SaveChangesAsync();
            return new ExamInstructionResponseDto()
            { 
                InstructionId = examInstruction.InstructionId,
                ExamId = examInstruction.ExamId, 
                Instruction = examInstruction.Instruction,
                SequenceNo = examInstruction.SequenceNo, 
                IsActive = examInstruction.IsActive 
            };
        }

        public async Task<List<ExamInstructionResponseDto>> GetAllExamInstructions()
        {
            var examInstructions = await _Context.ExamInstructions.Where(x => !x.IsDeleted).ToListAsync();
            List<ExamInstructionResponseDto> response = new();

            foreach (var item in examInstructions) 
            { 
                response.Add(new ExamInstructionResponseDto() 
                { 
                    InstructionId = item.InstructionId, 
                    ExamId = item.ExamId, Instruction = item.Instruction,
                    SequenceNo = item.SequenceNo, 
                    IsActive = item.IsActive, 
                    CreatedAt = item.CreatedAt 
                }); 
            }
            return response;
        }

        public async Task<ExamInstructionResponseDto> GetExamInstruction(long instructionId)
        {
            var examInstruction = await _Context.ExamInstructions.FirstOrDefaultAsync(x => x.InstructionId == instructionId && !x.IsDeleted);
            if (examInstruction == null)
            {
                throw new Exception("Exam instruction not found.");
            }
            return new ExamInstructionResponseDto()
            {
                InstructionId = examInstruction.InstructionId,
                ExamId = examInstruction.ExamId,
                Instruction = examInstruction.Instruction,
                SequenceNo = examInstruction.SequenceNo,
                IsActive = examInstruction.IsActive,
                CreatedAt = examInstruction.CreatedAt
            };
        }

        public async Task<ExamInstructionResponseDto> UpdateExamInstruction(ExamInstructionUpdateDto dto)
        {
            var examInstruction= await _Context.ExamInstructions.FirstOrDefaultAsync(x=>x.InstructionId ==dto.InstructionId && !x.IsDeleted);

            if (examInstruction == null)
            {
                throw new Exception("Exam instruction not found.");
            }
            examInstruction.ExamId=dto.ExamId;
            examInstruction.Instruction = dto.Instruction;
            examInstruction.SequenceNo=dto.SequenceNo;
            examInstruction.IsActive=dto.IsActive;
            examInstruction.UpdatedAt=DateTime.Now;

            await _Context.SaveChangesAsync();
            return new ExamInstructionResponseDto()
            {
                InstructionId = examInstruction.InstructionId,
                ExamId = examInstruction.ExamId,
                Instruction = examInstruction.Instruction,
                SequenceNo = examInstruction.SequenceNo,
                IsActive = examInstruction.IsActive,
                UpdatedAt = examInstruction.UpdatedAt
            };
        }
    }
}
