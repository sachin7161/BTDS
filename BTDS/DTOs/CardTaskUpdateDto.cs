using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class CardTaskUpdateDto
    {
        [Required]
        public int CardTaskId { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int EstimatedMinutes { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsSubmissionRequired { get; set; }

        public bool IsApprovalRequired { get; set; }

        public bool IsActive { get; set; }
    }
}
