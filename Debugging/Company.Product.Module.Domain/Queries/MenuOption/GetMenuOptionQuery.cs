using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.MenuOption;

namespace Company.Product.Module.Domain.Queries.MenuOption
{
    public class GetMenuOptionQuery(Guid id) : QueryBase<GetMenuOptionDto>
    {
        public Guid Id { get; set; } = id;
    }
}
