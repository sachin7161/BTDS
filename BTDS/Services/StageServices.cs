using BTDS.DTOs;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Services
{
    public class StageServices : IStagesService
    {

        private readonly BtdsdbContext _contex;
        private readonly ILogger<StageServices> _logger;
        public StageServices(BtdsdbContext contex,ILogger<StageServices> logger)  
        {
            _contex = contex;
            _logger = logger;
        }

        public async Task<StageResponseDto> AddStage(StageCreateDto dto)
        {
            _logger.LogInformation("Creating Stage");
            Stage stage = new Stage
            {
                Title = dto.Title,
                Duration = dto.Duration
            };

            _contex.Stages.Add(stage);
            _logger.LogInformation("Saving stage of Database");
            await _contex.SaveChangesAsync();
            _logger.LogInformation("Stage Saved Sucessfully. StageId :{StegeId}", stage.Id);

            return new StageResponseDto
            {
                Id = stage.Id,
                Title = stage.Title,
                IsActive = stage.IsActive ?? false,
                CreatedAt = stage.CreatedAt ?? DateTime.MinValue
            };



        }

        public async Task<string> DeleteStage(int stageId)
        {
            _logger.LogInformation("Start Deleting Process");
            var result = await _contex.Stages.FindAsync(stageId);
            if(result == null)
            {
                return "Stage not Found";
               
            }

            
            result.DeletedAt = DateTime.Now;
            result.IsActive = false;
           await _contex.SaveChangesAsync();
            _logger.LogInformation("Stage Deleted Successfull {Stage Id}:",result.Id);
            return "stage deleted Successfully";
        }

        public async Task<List<StageResponseDto>> GetAllStage()
        {
            _logger.LogInformation(" Started Fetch All Stage");
            var stages = await _contex.Stages.ToListAsync();
            _logger.LogInformation("Fetch All Stage");

            List<StageResponseDto> response = new List<StageResponseDto>();

            foreach (var stage in stages)
            {
                StageResponseDto dto = new StageResponseDto
                {
                    
                    Id = stage.Id,
                    Title = stage.Title!,
                    IsActive = stage.IsActive ?? false,
                    CreatedAt = stage.CreatedAt ?? DateTime.MinValue
                };

                response.Add(dto);
            }
           

            return response;

        }

        public async Task<StageResponseDto> GetStage(int stageId)
        {
            _logger.LogInformation("Start Fetch GetStage");
            var stage = await _contex.Stages.FindAsync(stageId);
            _logger.LogInformation("Fetch stage successfull");
            if (stage == null)
            {
                throw new Exception("Satage Not Found");
            }
            StageResponseDto str = new StageResponseDto
            {
                
                Id = stage.Id,
                Title = stage.Title,
                IsActive = stage.IsActive ?? false,
                CreatedAt = stage.CreatedAt ?? DateTime.MinValue
            };
           
            return str;
        }

        public async Task<StageResponseDto> UpdateStage(StageUpdateDto dto)
        {
            _logger.LogInformation("Stage Updating Process Start");
            var result = await _contex.Stages.FindAsync(dto.Id);

            if (result == null)
            {
                throw new Exception("Stage Not Found");
                
            }

            
            result.Title = dto.Title;
            result.Duration = dto.Duration;
            result.UpdatedAt = DateTime.Now;

            await _contex.SaveChangesAsync();
            _logger.LogInformation($"Updated {dto.Id}");
            return new StageResponseDto
            {
                
                Id = result.Id,
                Title = result.Title,
                IsActive = result.IsActive ?? false,
                CreatedAt = result.CreatedAt ?? DateTime.MinValue
            };

        }
    }
}
