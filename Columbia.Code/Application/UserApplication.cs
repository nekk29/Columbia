using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.User;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using MediatR;

namespace $safesolutionname$.Application
{
    public class UserApplication : ApplicationBase, IUserApplication
    {
        public UserApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _mediator.Send(new CreateUserCommand(createDto));

        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await _mediator.Send(new LoginCommand(loginDto));
    }
}
