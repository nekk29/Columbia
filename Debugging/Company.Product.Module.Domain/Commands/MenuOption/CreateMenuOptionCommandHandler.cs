using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.MenuOption
{
    public class CreateMenuOptionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateMenuOptionCommandValidator validator,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : CommandHandlerBase<CreateMenuOptionCommand, GetMenuOptionDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetMenuOptionDto>> HandleCommand(CreateMenuOptionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMenuOptionDto>();
            var menuOption = _mapper?.Map<Entity.MenuOption>(request.CreateDto);

            if (menuOption != null)
            {
                await menuOptionRepository.AddAsync(menuOption);
                await menuOptionRepository.SaveAsync();
            }

            var menuOptionDto = _mapper?.Map<GetMenuOptionDto>(menuOption);
            if (menuOptionDto != null) response.UpdateData(menuOptionDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
