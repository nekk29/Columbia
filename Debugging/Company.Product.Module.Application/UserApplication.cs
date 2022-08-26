using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.User;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using MediatR;

namespace Company.Product.Module.Application
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
