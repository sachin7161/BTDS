namespace BTDS.DTOs
{
    public class TenantResponseDto
    {
        public int TenantId { get; set; }

        public string TenantCode { get; set; }

        public string TenantName { get; set; }

        public string OrganizationType { get; set; }

        public string Logo { get; set; }

        public string Url { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
