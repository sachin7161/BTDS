namespace BTDS.DTOs
{
    public class QuestionOptionCreateDto
    {
        public long QuestionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
