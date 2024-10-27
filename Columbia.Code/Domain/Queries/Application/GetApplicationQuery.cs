using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Application;

namespace $safesolutionname$.Domain.Queries.Application
{
    public class GetApplicationQuery(Guid id) : QueryBase<GetApplicationDto>
    {
        public Guid Id { get; set; } = id;
    }
}
