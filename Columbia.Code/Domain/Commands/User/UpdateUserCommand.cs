using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class UpdateUserCommand : CommandBase<GetUserDto>
    {
        public UpdateUserCommand(UpdateUserDto updateDto) => UpdateDto = updateDto;
        public UpdateUserDto UpdateDto { get; set; }
    }
}
