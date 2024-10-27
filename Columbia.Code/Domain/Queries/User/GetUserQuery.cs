using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Queries.User
{
    public class GetUserQuery(Guid id) : QueryBase<GetUserDto>
    {
        public Guid Id { get; set; } = id;
    }
}
