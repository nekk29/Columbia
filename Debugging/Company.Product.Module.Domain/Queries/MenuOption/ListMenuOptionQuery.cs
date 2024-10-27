using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Domain.Queries.MenuOption
{
    public class ListMenuOptionQuery(string applicationCode, bool includeAll = true) : QueryBase<IEnumerable<ListMenuOptionDto>>
    {
        public string ApplicationCode { get; set; } = applicationCode;
        public bool IncludeAll { get; set; } = includeAll;
    }
}
