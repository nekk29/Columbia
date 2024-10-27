namespace $safesolutionname$.Dto.MenuOption
{
    public class TreeMenuOptionDto : GetMenuOptionDto
    {
        public IEnumerable<TreeMenuOptionDto> Children { get; set; } = null!;
    }
}
