using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Queries.User
{
    public class GetUserQuery : QueryBase<GetUserDto>
    {
        public GetUserQuery(Guid id) => Id = id;
        public Guid Id { get; set; }
    }
}
