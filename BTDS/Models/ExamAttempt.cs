using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDS.Models
{
    public class ExamAttempt
    {
        [Key]
        public long AttemptId { get; set; }
        public long UserId { get; set; }
        public long ExamId { get; set; }
        public int AttemptNo { get; set; } = 1;
        public DateTime StartedAt { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int? TimeTaken { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalMarks { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal ObtainedMarks { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Percentage { get; set; }
        public string Result { get; set; }
        public string Status { get; set; } = "InProgress";
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
