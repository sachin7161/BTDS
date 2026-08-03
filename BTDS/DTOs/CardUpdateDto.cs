using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class CardUpdateDto
    {
        [Required]
        public int CardsId { get; set; }

        [Required]
        public int ModuleId { get; set; }

        [Required]
        public int CardTypeId { get; set; }

        [Required]
        public int DifficultyLevelId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        public string? LearningObjective { get; set; }

        public string? Description { get; set; }

        public int EstimatedMinutes { get; set; }

        public int SequenceNo { get; set; }

        public decimal? PassingMarks { get; set; }

        public decimal? MaxMarks { get; set; }

        public bool IsMandatory { get; set; }

        public bool AllowRetake { get; set; }

        public bool IsActive { get; set; }
    }
}
