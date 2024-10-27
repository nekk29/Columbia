using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.MenuOption
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
