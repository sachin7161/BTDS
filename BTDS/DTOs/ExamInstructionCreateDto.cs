namespace BTDS.DTOs
{
    public class ExamInstructionCreateDto
    {
        public long ExamId { get; set; }

        public string Instruction { get; set; } = string.Empty;

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
