using AutoMapper;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Module;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Domain.Queries.Module
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
