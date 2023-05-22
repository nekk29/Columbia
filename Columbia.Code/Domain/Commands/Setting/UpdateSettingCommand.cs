using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class UpdateSettingCommand : CommandBase<GetSettingDto>
    {
        public UpdateSettingCommand(UpdateSettingDto updateDto) => UpdateDto = updateDto;
        public UpdateSettingDto UpdateDto { get; set; }
    }
}
