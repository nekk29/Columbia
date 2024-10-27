using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Domain.Queries.MenuOption
{
    public class TreeMenuOptionQuery(string applicationCode, bool includeAll = true) : QueryBase<IEnumerable<TreeMenuOptionDto>>
    {
        public string ApplicationCode { get; set; } = applicationCode;
        public bool IncludeAll { get; set; } = includeAll;
    }
}
