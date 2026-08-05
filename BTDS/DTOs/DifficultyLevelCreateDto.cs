using System.ComponentModel.DataAnnotations;

namespace BTDS.DTOs
{
    public class DifficultyLevelCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int SequenceNo { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
