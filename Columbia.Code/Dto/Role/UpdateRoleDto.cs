﻿namespace $safesolutionname$.Dto.Role
{
    public class UpdateRoleDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? NormalizedName { get; set; } = null!;
        public bool Status { get; set; }
    }
}
