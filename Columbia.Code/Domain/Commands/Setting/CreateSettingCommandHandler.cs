using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;
using $safesolutionname$.Repository.Abstractions;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class CreateSettingCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateSettingCommandValidator validator,
        ISettingRepository settingRepository
    ) : CommandHandlerBase<CreateSettingCommand, GetSettingDto>(unitOfWork, mapper, validator)
    {
        protected override bool UseTransaction => false;

        public override async Task<ResponseDto<GetSettingDto>> HandleCommand(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSettingDto>();
            var setting = _mapper?.Map<Entity.Setting>(request.CreateDto);

            if (setting != null)
                await settingRepository.AddAsync(setting);

            var settingDto = _mapper?.Map<GetSettingDto>(setting);
            if (settingDto != null) response.UpdateData(settingDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
