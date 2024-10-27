using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Module
{
    public class DeleteModuleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteModuleCommandValidator validator,
        IRepository<Entity.Module> moduleRepository
    ) : CommandHandlerBase<DeleteModuleCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var module = await moduleRepository.GetByAsync(x => x.Id == request.Id);

            if (module != null)
            {
                await moduleRepository.DeleteAsync(module);
                await moduleRepository.SaveAsync();
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
