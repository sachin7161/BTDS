namespace BTDS.DTOs
{
    public class ExamAttemptCreateDto
    {
        public long UserId { get; set; }

        public long ExamId { get; set; }

        public int AttemptNo { get; set; } = 1;

        public DateTime StartedAt { get; set; }

        public decimal TotalMarks { get; set; }

        public string Status { get; set; } = "InProgress";

        public bool IsActive { get; set; } = true;
    }
}
