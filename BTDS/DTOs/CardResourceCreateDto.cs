using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class CardResourceCreateDto
    {
        [Required]
        public int CardId { get; set; }

        [Required]
        public int ResourceTypeId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Url { get; set; }

        [MaxLength(300)]
        public string? FileName { get; set; }

        [MaxLength(1000)]
        public string? FilePath { get; set; }

        [MaxLength(500)]
        public string? Thumbnail { get; set; }

        public int SequenceNo { get; set; }

        public bool IsDownloadable { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}
