using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Domain.Queries.Module
{
    public class ListModuleQuery(Guid? applicationId = null, bool includeActions = true) : QueryBase<IEnumerable<ListModuleDto>>
    {
        public Guid? ApplicationId { get; set; } = applicationId;
        public bool IncludeActions { get; set; } = includeActions;
    }
}
