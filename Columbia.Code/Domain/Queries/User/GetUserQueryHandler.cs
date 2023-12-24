using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.User
{
    public class GetUserQueryHandler : QueryHandlerBase<GetUserQuery, GetUserDto>
    {
        private readonly IRepository<Entity.AspNetUser> _userRepository;

        public GetUserQueryHandler(
            IMapper mapper,
            IRepository<Entity.AspNetUser> userRepository
        ) : base(mapper)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ResponseDto<GetUserDto>> HandleQuery(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();
            var user = await _userRepository.GetByAsync(x => x.Id == request.Id, x => x.Roles);
            var userDto = _mapper?.Map<GetUserDto>(user);
        
            if (userDto != null)
            {
                userDto.RoleIds = user?.Roles.Select(x => x.Id) ?? Array.Empty<Guid>();
                response.UpdateData(userDto);
            }

            return await Task.FromResult(response);
        }
    }
}
