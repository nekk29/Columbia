using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class UpdateUserCommand(UpdateUserDto updateDto) : CommandBase<GetUserDto>
    {
        public UpdateUserDto UpdateDto { get; set; } = updateDto;
    }
}
