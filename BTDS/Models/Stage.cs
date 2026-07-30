using System;
using System.Collections.Generic;

namespace BTDS.Models;

public partial class Stage
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Duration { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
