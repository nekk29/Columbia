using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.MenuOption
{
    public class UpdateMenuOptionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateMenuOptionCommandValidator validator,
        IRepository<Entity.MenuOption> menuOptionRepository
    ) : CommandHandlerBase<UpdateMenuOptionCommand, GetMenuOptionDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<GetMenuOptionDto>> HandleCommand(UpdateMenuOptionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMenuOptionDto>();

            var menuOption = await menuOptionRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (menuOption != null)
            {
                _mapper?.Map(request.UpdateDto, menuOption);
                await menuOptionRepository.UpdateAsync(menuOption);
            }

            var menuOptionDto = _mapper?.Map<GetMenuOptionDto>(menuOption);
            if (menuOptionDto != null) response.UpdateData(menuOptionDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
