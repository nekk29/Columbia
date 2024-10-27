using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Application;

namespace Company.Product.Module.Domain.Queries.Application
{
    public class GetApplicationQuery(Guid id) : QueryBase<GetApplicationDto>
    {
        public Guid Id { get; set; } = id;
    }
}
