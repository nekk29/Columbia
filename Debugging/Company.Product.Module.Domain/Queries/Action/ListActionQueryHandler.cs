using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Action;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Action
{
    public class ListActionQueryHandler(
        IMapper mapper,
        IRepository<Entity.Action> actionRepository
    ) : QueryHandlerBase<ListActionQuery, IEnumerable<ListActionDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListActionDto>>> HandleQuery(ListActionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListActionDto>>();

            var items = request.ModuleId.HasValue ?
                await actionRepository.FindByAsync(x => x.ModuleId == request.ModuleId.Value) :
                await actionRepository.FindAll().ToListAsync(cancellationToken);

            var itemDtos = _mapper?.Map<IEnumerable<ListActionDto>>(items.OrderBy(x => x.Code));

            response.UpdateData(itemDtos ?? new List<ListActionDto>());

            return await Task.FromResult(response);
        }
    }
}
