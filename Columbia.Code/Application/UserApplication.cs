using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.User;
using $safesolutionname$.Domain.Queries.User;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Application
{
    public class UserApplication(IMediator mediator) : ApplicationBase(mediator), IUserApplication
    {
        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await _mediator.Send(new CreateUserCommand(createDto));

        public async Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto)
            => await _mediator.Send(new UpdateUserCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteUserCommand(id));

        public async Task<ResponseDto<GetUserDto>> Get(Guid id)
            => await _mediator.Send(new GetUserQuery(id));

        public async Task<ResponseDto<IEnumerable<ListUserDto>>> List()
            => await _mediator.Send(new ListUserQuery());

        public async Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> searchParams)
            => await _mediator.Send(new SearchUserQuery(searchParams));

        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await _mediator.Send(new LoginCommand(loginDto));

        public async Task<ResponseDto> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
            => await _mediator.Send(new ForgotPasswordCommand(forgotPasswordDto));

        public async Task<ResponseDto> ResetPassword(ResetPasswordDto resetPasswordDto)
            => await _mediator.Send(new ResetPasswordCommand(resetPasswordDto));
    }
}
