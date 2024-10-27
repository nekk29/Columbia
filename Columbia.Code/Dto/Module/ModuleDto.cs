namespace $safesolutionname$.Dto.Module
{
    public class ModuleDto
    {
        public Guid ApplicationId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}
