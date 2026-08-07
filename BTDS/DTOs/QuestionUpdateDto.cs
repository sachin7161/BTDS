namespace BTDS.DTOs
{
    public class QuestionUpdateDto
    {
        public long QuestionId { get; set; }

        public long ExamId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public string QuestionType { get; set; } = string.Empty;

        public decimal Marks { get; set; }

        public string? Explanation { get; set; }

        public string DifficultyLevel { get; set; } = "Easy";

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; }
    }
}
