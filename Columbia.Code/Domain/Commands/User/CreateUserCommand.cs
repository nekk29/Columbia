using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class CreateUserCommand(CreateUserDto createDto) : CommandBase<GetUserDto>
    {
        public CreateUserDto CreateDto { get; set; } = createDto;
    }
}
