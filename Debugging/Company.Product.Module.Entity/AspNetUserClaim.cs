﻿namespace Company.Product.Module.Entity
{
    public partial class AspNetUserClaim
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        public virtual AspNetUser User { get; set; } = null!;
    }
}
