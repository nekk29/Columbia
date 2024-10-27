using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Module
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
