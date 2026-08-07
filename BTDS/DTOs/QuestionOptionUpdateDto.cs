namespace BTDS.DTOs
{
    public class QuestionOptionUpdateDto
    {
        public long OptionId { get; set; }

        public long QuestionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; }
    }
}
