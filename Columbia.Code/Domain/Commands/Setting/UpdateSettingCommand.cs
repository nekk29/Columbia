using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class UpdateSettingCommand(UpdateSettingDto updateDto) : CommandBase<GetSettingDto>
    {
        public UpdateSettingDto UpdateDto { get; set; } = updateDto;
    }
}
