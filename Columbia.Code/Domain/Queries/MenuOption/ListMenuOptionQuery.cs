using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class ListMenuOptionQuery(string applicationCode, bool includeAll = true) : QueryBase<IEnumerable<ListMenuOptionDto>>
    {
        public string ApplicationCode { get; set; } = applicationCode;
        public bool IncludeAll { get; set; } = includeAll;
    }
}
