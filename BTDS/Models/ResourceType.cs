using System.ComponentModel.DataAnnotations;

namespace BTDS.Models
{
    public class ResourceType
    {
      
        public int ResourceTypeId { get; set; }

       
        public string Name { get; set; } = string.Empty;

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
