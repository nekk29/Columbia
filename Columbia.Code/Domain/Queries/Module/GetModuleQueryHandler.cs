using AutoMapper;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Module
{
    public class GetModuleQueryHandler(
        IMapper mapper,
        IRepository<Entity.Module> moduleRepository
    ) : QueryHandlerBase<GetModuleQuery, GetModuleDto>(mapper)
    {
        protected override async Task<ResponseDto<GetModuleDto>> HandleQuery(GetModuleQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetModuleDto>();
            var module = await moduleRepository.GetByAsync(x => x.Id == request.Id, x => x.Application);
            var moduleDto = _mapper?.Map<GetModuleDto>(module);

            if (moduleDto != null)
                response.UpdateData(moduleDto);

            return await Task.FromResult(response);
        }
    }
}
