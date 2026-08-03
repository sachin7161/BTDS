using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class DifficultyLevelUpdateDto
    {
        [Required]
        public int DifficultyLevelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; }
    }
}
