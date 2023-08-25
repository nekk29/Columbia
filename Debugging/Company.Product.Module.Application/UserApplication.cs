using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.User;
using Company.Product.Module.Domain.Queries.User;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Token;
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

        public async Task<ResponseDto<AccessTokenDto>> RenewSession()
            => await _mediator.Send(new RenewSessionCommand());

        public async Task<ResponseDto> ForgotPassword(string email)
            => await _mediator.Send(new ForgotPasswordCommand(email));

        public async Task<ResponseDto> ResetPassword(ResetPasswordDto resetPasswordDto)
            => await _mediator.Send(new ResetPasswordCommand(resetPasswordDto));
    }
}
