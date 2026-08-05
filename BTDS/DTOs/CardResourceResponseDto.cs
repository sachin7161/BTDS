namespace BTDS.DTOs
{
    public class CardResourceResponseDto
    {
        public int CardResourceId { get; set; }

        public int CardId { get; set; }

        public int ResourceTypeId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Url { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public string? Thumbnail { get; set; }

        public int SequenceNo { get; set; }

        public bool IsDownloadable { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
