namespace BTDS.DTOs
{
    public class GateResponseDto
    {
        public int GateId { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int DurationWeeks { get; set; }

        public int TotalCards { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
