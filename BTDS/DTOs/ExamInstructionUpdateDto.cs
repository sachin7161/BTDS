namespace BTDS.DTOs
{
    public class ExamInstructionUpdateDto
    {
        public long InstructionId { get; set; }

        public long ExamId { get; set; }

        public string Instruction { get; set; } = string.Empty;

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; }
    }
}
