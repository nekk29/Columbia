using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Module;

namespace Company.Product.Module.Domain.Queries.Module
{
    public class ListModuleQuery(Guid? applicationId = null, bool includeActions = true) : QueryBase<IEnumerable<ListModuleDto>>
    {
        public Guid? ApplicationId { get; set; } = applicationId;
        public bool IncludeActions { get; set; } = includeActions;
    }
}
