using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Application
{
    public class DeleteApplicationCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteApplicationCommandValidator validator,
        IRepository<Entity.Application> applicationRepository
    ) : CommandHandlerBase<DeleteApplicationCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var application = await applicationRepository.GetByAsync(x => x.Id == request.Id);

            if (application != null)
            {
                await applicationRepository.DeleteAsync(application);
                await applicationRepository.SaveAsync();

            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
