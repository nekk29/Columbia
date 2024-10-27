using Company.Product.Module.Dto.Action;

namespace Company.Product.Module.Dto.Module
{
    public class ListModuleDto : GetModuleDto
    {
        public IEnumerable<GetActionDto> Actions { get; set; } = null!;
    }
}
