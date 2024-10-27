using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Client;

namespace Company.Product.Module.Domain.Commands.Client
{
    public class CreateOrUpdateClientCommand(CreateOrUpdateClientDto createDto) : CommandBase<CreateOrUpdateClientResultDto>
    {
        public CreateOrUpdateClientDto CreateDto { get; set; } = createDto;
    }
}
