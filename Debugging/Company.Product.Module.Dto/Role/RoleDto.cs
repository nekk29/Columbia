﻿namespace Company.Product.Module.Dto.Role
{
    public class RoleDto
    {
        public Guid ApplicationId { get; set; }
        public string? Name { get; set; } = null!;
        public string? NormalizedName { get; set; } = null!;
    }
}
