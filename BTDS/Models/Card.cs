using System;
using System.Collections.Generic;

namespace BTDS.Models;

public partial class Card
{
    public int Id { get; set; }

    public int? StageId { get; set; }

    public string? TechStack { get; set; }

    public string? TaskTitle { get; set; }

    public string? LearningTopics { get; set; }

    public int? Duration { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Stage? Stage { get; set; }
}
