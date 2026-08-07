namespace BTDS.DTOs
{
    public class QuestionOptionResponseDto
    {
        public long OptionId { get; set; }

        public long QuestionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
