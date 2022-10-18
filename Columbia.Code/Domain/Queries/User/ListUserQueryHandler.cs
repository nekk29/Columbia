using AutoMapper;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.User
{
    public class ListUserQueryHandler : QueryHandlerBase<ListUserQuery, IEnumerable<ListUserDto>>
    {
        private readonly IRepository<Entity.AspNetUser> _userRepository;

        public ListUserQueryHandler(
            IMapper mapper,
            IRepository<Entity.AspNetUser> userRepository
        ) : base(mapper)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListUserDto>>> HandleQuery(ListUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListUserDto>>();
            var items = await _userRepository.FindAll().Where(x => x.IsActive).ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListUserDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListUserDto>());

            return await Task.FromResult(response);
        }
    }
}
