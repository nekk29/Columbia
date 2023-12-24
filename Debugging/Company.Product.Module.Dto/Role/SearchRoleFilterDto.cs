namespace Company.Product.Module.Dto.Role
{
    public class SearchRoleFilterDto
    {
        public string? Query { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? NormalizedName { get; set; } = null!;
    }
}
