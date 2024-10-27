using $safesolutionname$.Dto.Action;

namespace $safesolutionname$.Dto.Module
{
    public class ListModuleDto : GetModuleDto
    {
        public IEnumerable<GetActionDto> Actions { get; set; } = null!;
    }
}
