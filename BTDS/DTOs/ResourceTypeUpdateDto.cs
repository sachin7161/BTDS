using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class ResourceTypeUpdateDto
    {
        [Required]
        public int ResourceTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
