using System.Linq.Expressions;
using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Extensions;

namespace Company.Product.Module.Domain.Queries.User
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

            var users = await _userRepository.SearchByAsNoTrackingAsync(
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
