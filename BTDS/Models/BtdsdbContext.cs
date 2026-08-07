using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Models;

public partial class BtdsdbContext :DbContext
{
    

    public BtdsdbContext(DbContextOptions<BtdsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Gate> Gates { get; set; }
    public virtual DbSet<Module> Modules { get; set; }
    public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }    
    public virtual DbSet<CardType> CardTypes { get; set; }
    public virtual DbSet<CardTask>CardTasks { get; set; }
    public virtual DbSet<ResourceType> ResourceTypes { get; set; }
    public virtual DbSet<CardResource> CardResources { get; set; }
    public virtual DbSet<Tenant> Tenants { get; set; }
    public virtual DbSet<ExamInstruction> ExamInstructions { get; set; } 
    public virtual DbSet<ExamAttempt> ExamAttempts { get; set; } 
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

}
