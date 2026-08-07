namespace BTDS.DTOs
{
    public class ExamAttemptResponseDto
    {
        public long AttemptId { get; set; }

        public long UserId { get; set; }

        public long ExamId { get; set; }

        public int AttemptNo { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime SubmittedAt { get; set; }

        public int TimeTaken { get; set; }

        public decimal TotalMarks { get; set; }

        public decimal ObtainedMarks { get; set; }

        public decimal Percentage { get; set; }

        public string Result { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
