using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDS.Models
{
    public class CardTask
    {
        public int CardTaskId { get; set; }

        
        public int CardId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int EstimatedMinutes { get; set; } = 10;

        public bool IsMandatory { get; set; } = true;

        public bool IsSubmissionRequired { get; set; } = false;

        public bool IsApprovalRequired { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public int? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        
    }
}
