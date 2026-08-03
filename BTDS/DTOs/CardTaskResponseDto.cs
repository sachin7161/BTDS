namespace BTDS.DTOs
{
    public class CardTaskResponseDto
    {
        public int CardTaskId { get; set; }

        public int CardId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int EstimatedMinutes { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsSubmissionRequired { get; set; }

        public bool IsApprovalRequired { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
