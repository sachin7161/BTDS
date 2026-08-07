using System.ComponentModel.DataAnnotations;
namespace BTDS.Models
{
    public class ExamInstruction
    {
        [Key]
        public long InstructionId {  get; set; }
        public long ExamId { get; set; }

        public string Instruction { get; set; } = string.Empty;

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int DeletedBy { get; set; }

        public DateTime DeletedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
