using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.User
{
    public class ListUserQueryHandler(
        IMapper mapper,
        IRepository<Entity.AspNetUser> userRepository
    ) : QueryHandlerBase<ListUserQuery, IEnumerable<ListUserDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListUserDto>>> HandleQuery(ListUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListUserDto>>();
            var items = await userRepository.FindAll().Where(x => x.IsActive).ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListUserDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListUserDto>());

            return await Task.FromResult(response);
        }
    }
}
