using AutoMapper;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Application;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Application
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
