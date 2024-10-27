using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class GetMenuOptionQuery(Guid id) : QueryBase<GetMenuOptionDto>
    {
        public Guid Id { get; set; } = id;
    }
}
