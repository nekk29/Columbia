using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Application
{
    public class ListApplicationQueryHandler(
        IMapper mapper,
        IRepository<Entity.Application> applicationRepository
    ) : QueryHandlerBase<ListApplicationQuery, IEnumerable<ListApplicationDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListApplicationDto>>> HandleQuery(ListApplicationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListApplicationDto>>();
            var items = await applicationRepository.FindAll().ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListApplicationDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListApplicationDto>());

            return await Task.FromResult(response);
        }
    }
}
