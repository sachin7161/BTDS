using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDS.Models
{
    public class Question
    {
        [Key]
        public long QuestionId { get; set; }
        public long ExamId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty;
        [Column(TypeName = "decimal(5,2)")]
        public decimal Marks { get; set; } = 1;
        public string Explanation { get; set; }
        public string DifficultyLevel { get; set; } = "Easy";
        public int SequenceNo { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
