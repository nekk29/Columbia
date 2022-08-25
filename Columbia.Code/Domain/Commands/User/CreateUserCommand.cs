using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class CreateUserCommand : CommandBase<GetUserDto>
    {
        public CreateUserCommand(CreateUserDto createDto) => CreateDto = createDto;
        public CreateUserDto CreateDto { get; set; }
    }
}
