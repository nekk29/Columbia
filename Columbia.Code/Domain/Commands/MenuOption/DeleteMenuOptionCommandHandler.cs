using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.MenuOption
{
    public class DeleteMenuOptionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteMenuOptionCommandValidator validator,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : CommandHandlerBase<DeleteMenuOptionCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteMenuOptionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var menuOption = await menuOptionRepository.GetByAsync(x => x.Id == request.Id);

            if (menuOption != null)
            {
                await menuOptionRepository.DeleteAsync(menuOption);
                await menuOptionRepository.SaveAsync();
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
