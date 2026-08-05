using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class GateUpdateDto
    {
        [Required]
        public int GateId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int DurationWeeks { get; set; }

        public int TotalCards { get; set; }

        public bool IsActive { get; set; }
    }
}
