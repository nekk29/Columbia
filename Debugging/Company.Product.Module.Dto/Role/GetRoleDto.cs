namespace Company.Product.Module.Dto.Role
{
    public class GetRoleDto : RoleDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
