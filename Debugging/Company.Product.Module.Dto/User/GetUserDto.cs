namespace Company.Product.Module.Dto.User
{
    public class GetUserDto : UserDto
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; } = Array.Empty<Guid>();
        public bool IsActive { get; set; }
    }
}
