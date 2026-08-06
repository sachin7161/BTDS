namespace BTDS.DTOs.Auth
{
    public class RegisterResponseDto
    {
        public string UserId { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int TenantId { get; set; }
    }
}
