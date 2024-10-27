namespace Company.Product.Module.Dto.Role
{
    public class UpdateRoleDto : RoleDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
