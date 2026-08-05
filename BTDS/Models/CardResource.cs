using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDS.Models
{
    public class CardResource
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

        public bool IsDownloadable { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public int? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

       
    }
}
