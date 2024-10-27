using AutoMapper;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class ListSettingQueryHandler(
        IMapper mapper,
        IRepository<Entity.Setting> settingRepository
    ) : QueryHandlerBase<ListSettingQuery, IEnumerable<ListSettingDto>>(mapper)
    {
        protected override async Task<ResponseDto<IEnumerable<ListSettingDto>>> HandleQuery(ListSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListSettingDto>>();
            var items = await settingRepository.FindAll().ToListAsync(cancellationToken);
            var itemDtos = _mapper?.Map<IEnumerable<ListSettingDto>>(items);

            response.UpdateData(itemDtos ?? new List<ListSettingDto>());

            return await Task.FromResult(response);
        }
    }
}
