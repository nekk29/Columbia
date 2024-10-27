using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Action;

namespace $safesolutionname$.Domain.Queries.Action
{
    public class GetActionQuery(Guid id) : QueryBase<GetActionDto>
    {
        public Guid Id { get; set; } = id;
    }
}
