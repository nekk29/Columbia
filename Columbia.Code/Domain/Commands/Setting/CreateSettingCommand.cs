using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class CreateSettingCommand(CreateSettingDto createDto) : CommandBase<GetSettingDto>
    {
        public CreateSettingDto CreateDto { get; set; } = createDto;
    }
}
