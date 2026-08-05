using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class CardTaskCreateDto
    {
        [Required]
        public int CardId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int EstimatedMinutes { get; set; } = 10;

        public bool IsMandatory { get; set; } = true;

        public bool IsSubmissionRequired { get; set; } = false;

        public bool IsApprovalRequired { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
