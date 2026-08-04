using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDS.Models
{
    public class Card
    {
        [Key]
        public int CardsId { get; set; }

        public int ModuleId { get; set; }

       
        public int CardTypeId { get; set; }

      
        public int DifficultyLevelId { get; set; }

       
        public string Code { get; set; } = string.Empty;

       
        public string Title { get; set; } = string.Empty;

        public string? LearningObjective { get; set; }

        public string? Description { get; set; }

        public int EstimatedMinutes { get; set; } = 30;

        public int SequenceNo { get; set; }

       
        public decimal? PassingMarks { get; set; }

       
        public decimal? MaxMarks { get; set; }

        public bool IsMandatory { get; set; } = true;

        public bool AllowRetake { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public int? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }

       

    }
}
