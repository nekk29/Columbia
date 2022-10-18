using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Base;
using System.Linq.Expressions;

namespace $safesolutionname$.Domain.Queries.User
{
    public class SearchUserQueryHandler : SearchQueryHandlerBase<SearchUserQuery, SearchUserFilterDto, SearchUserDto>
    {
        private readonly IRepository<Entity.AspNetUser> _userRepository;

        public SearchUserQueryHandler(
            IMapper mapper,
            IRepository<Entity.AspNetUser> userRepository
        ) : base(mapper)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchUserDto>>> HandleQuery(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchUserDto>>();

            Expression<Func<Entity.AspNetUser, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            /*
                Place your filters here...
            */

            var users = await _userRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null, //Include sort expressions...
                filter //Include navigation properties...
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
