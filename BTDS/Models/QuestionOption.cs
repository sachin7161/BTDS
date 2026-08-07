using System.ComponentModel.DataAnnotations;

namespace BTDS.Models
{
    public class QuestionOption
    {
        [Key]
        public long OptionId { get; set; }

        public long QuestionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }

        public int SequenceNo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
