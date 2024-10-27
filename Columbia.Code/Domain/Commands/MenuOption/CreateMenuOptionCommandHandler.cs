using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.MenuOption
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
