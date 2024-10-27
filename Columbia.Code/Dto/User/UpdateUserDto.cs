﻿namespace $safesolutionname$.Dto.User
{
    public class UpdateUserDto
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public bool IsActive { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; } = null!;
    }
}
