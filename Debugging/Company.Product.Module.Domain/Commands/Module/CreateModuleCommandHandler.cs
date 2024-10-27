using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Module;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Module
{
    public class CreateModuleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateModuleCommandValidator validator,
        IRepository<Entity.Module> moduleRepository
    ) : CommandHandlerBase<CreateModuleCommand, GetModuleDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetModuleDto>> HandleCommand(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetModuleDto>();
            var module = _mapper?.Map<Entity.Module>(request.CreateDto);

            if (module != null)
            {
                await moduleRepository.AddAsync(module);
                await moduleRepository.SaveAsync();
            }

            var moduleDto = _mapper?.Map<GetModuleDto>(module);
            if (moduleDto != null) response.UpdateData(moduleDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
