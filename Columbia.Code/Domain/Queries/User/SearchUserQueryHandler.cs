using AutoMapper;
using System.Linq.Expressions;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Queries.User
{
    public class SearchUserQueryHandler(
        IMapper mapper,
        IRepository<Entity.AspNetUser> userRepository
    ) : SearchQueryHandlerBase<SearchUserQuery, SearchUserFilterDto, SearchUserDto>(mapper)
    {
        protected override async Task<ResponseDto<SearchResultDto<SearchUserDto>>> HandleQuery(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchUserDto>>();

            Expression<Func<Entity.AspNetUser, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!string.IsNullOrEmpty(filters?.Query))
            {
                filter = filter.And(x =>
                    x.UserName!.Contains(filters.Query!) ||
                    x.FirstName!.Contains(filters.Query!) ||
                    x.LastName!.Contains(filters.Query!) ||
                    x.Email!.Contains(filters.Query!) ||
                    x.PhoneNumber!.Contains(filters.Query!)
                );
            }

            var users = await userRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var userDtos = _mapper?.Map<IEnumerable<SearchUserDto>>(users.Items);

            var searchResult = new SearchResultDto<SearchUserDto>(
                userDtos ?? new List<SearchUserDto>(),
                users.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
