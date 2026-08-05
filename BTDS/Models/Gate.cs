using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BTDS.Models
{
    public class Gate
    {
      
        public int GateId { get; set; }

        
        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SequenceNo { get; set; }

        public int DurationWeeks { get; set; }

        public int TotalCards { get; set; }

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
