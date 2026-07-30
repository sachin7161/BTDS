namespace BTDS.DTOs
{
    public class CardResponseDto
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string Techstack { get; set; }
        public string Tasktitle { get; set; }
        public string Learningtopic { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
