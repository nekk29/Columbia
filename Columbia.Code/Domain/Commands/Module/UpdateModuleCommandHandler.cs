using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Module
{
    public class UpdateModuleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateModuleCommandValidator validator,
        IRepository<Entity.Module> moduleRepository
    ) : CommandHandlerBase<UpdateModuleCommand, GetModuleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetModuleDto>> HandleCommand(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetModuleDto>();

            var module = await moduleRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (module != null)
            {
                _mapper?.Map(request.UpdateDto, module);
                await moduleRepository.UpdateAsync(module);
            }

            var moduleDto = _mapper?.Map<GetModuleDto>(module);
            if (moduleDto != null) response.UpdateData(moduleDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
