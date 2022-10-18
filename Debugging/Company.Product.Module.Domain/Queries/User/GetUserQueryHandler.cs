using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.User
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
            var user = await _userRepository.GetByAsync(x => x.Id == request.Id && x.IsActive);
            var userDto = _mapper?.Map<GetUserDto>(user);

            if (userDto != null)
                response.UpdateData(userDto);

            return await Task.FromResult(response);
        }
    }
}
