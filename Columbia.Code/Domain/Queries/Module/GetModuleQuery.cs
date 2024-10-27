using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Domain.Queries.Module
{
    public class GetModuleQuery(Guid id) : QueryBase<GetModuleDto>
    {
        public Guid Id { get; set; } = id;
    }
}
