using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Domain.Queries.MenuOption
{
    public class TreeMenuOptionQuery(string applicationCode, bool includeAll = true) : QueryBase<IEnumerable<TreeMenuOptionDto>>
    {
        public string ApplicationCode { get; set; } = applicationCode;
        public bool IncludeAll { get; set; } = includeAll;
    }
}
