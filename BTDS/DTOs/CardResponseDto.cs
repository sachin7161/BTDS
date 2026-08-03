namespace BTDS.DTOs
{
    public class CardResponseDto
    {
        public int CardsId { get; set; }

        public int ModuleId { get; set; }

        public int CardTypeId { get; set; }

        public int DifficultyLevelId { get; set; }

        public string Code { get; set; } = string.Empty;

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

        public DateTime CreatedAt { get; set; }
    }
}
