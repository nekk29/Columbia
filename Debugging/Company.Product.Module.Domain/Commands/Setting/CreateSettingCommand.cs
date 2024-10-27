using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Commands.Setting
{
    public class CreateSettingCommand(CreateSettingDto createDto) : CommandBase<GetSettingDto>
    {
        public CreateSettingDto CreateDto { get; set; } = createDto;
    }
}
