using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BTDS.Models
{
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public int TenantId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
