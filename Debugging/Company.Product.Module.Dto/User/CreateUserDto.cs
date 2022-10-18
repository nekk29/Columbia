﻿namespace Company.Product.Module.Dto.User
{
    public class CreateUserDto
    {
        public string? UserName { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
