using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.RelatedSample
{
    public class ListRelatedSampleQueryHandler(
        IMapper mapper,
        IRepository<Entity.RelatedSample> relatedSampleRepository
    ) : QueryHandlerBase<ListRelatedSampleQuery, IEnumerable<ListRelatedSampleDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> HandleQuery(ListRelatedSampleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListRelatedSampleDto>>();
            var items = await relatedSampleRepository.FindAll().ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListRelatedSampleDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListRelatedSampleDto>());

            return await Task.FromResult(response);
        }
    }
}
