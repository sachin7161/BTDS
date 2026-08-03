using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Models;

public partial class BtdsdbContext : DbContext
{
    public BtdsdbContext()
    {
    }

    public BtdsdbContext(DbContextOptions<BtdsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Gate> Gates { get; set; }
    public virtual DbSet<Module> Modules { get; set; }

}
