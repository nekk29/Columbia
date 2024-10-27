using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Module;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Module
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
