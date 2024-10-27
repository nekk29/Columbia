using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Queries.Setting
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
