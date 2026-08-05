namespace BTDS.DTOs
{
    public class CardTypeResponseDto
    {
        public int CardTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
