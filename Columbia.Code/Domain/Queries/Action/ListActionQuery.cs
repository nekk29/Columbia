using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Action;

namespace $safesolutionname$.Domain.Queries.Action
{
    public class ListActionQuery(Guid? moduleId = null) : QueryBase<IEnumerable<ListActionDto>>
    {
        public Guid? ModuleId { get; set; } = moduleId;
    }
}
