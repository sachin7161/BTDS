using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BTDS.Models
{
    public class IdentityDb:IdentityDbContext<AppUser>
    {
        public IdentityDb(DbContextOptions<IdentityDb>options):base(options) { 
        }
    }
}
