namespace BTDS.DTOs
{
    public class DifficultyLevelResponseDto
    {
        public int DifficultyLevelId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
