namespace BTDS.DTOs
{
    public class ModuleResponseDto
    {
        public int ModuleId { get; set; }

        public int GateId { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public decimal EstimatedHours { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
