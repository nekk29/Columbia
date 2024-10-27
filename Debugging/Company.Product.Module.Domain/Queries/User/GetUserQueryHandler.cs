using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.User
{
    public class GetUserQueryHandler(
        IMapper mapper,
        IRepository<Entity.AspNetUser> userRepository
    ) : QueryHandlerBase<GetUserQuery, GetUserDto>(mapper)
    {
        protected override async Task<ResponseDto<GetUserDto>> HandleQuery(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();
            var user = await userRepository.GetByAsync(x => x.Id == request.Id, x => x.Roles);
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
