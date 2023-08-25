using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Token;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Application.Abstractions
{
    public interface IUserApplication
    {
        Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto);
        Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetUserDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListUserDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> searchParams);
        Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto);
        Task<ResponseDto<AccessTokenDto>> RenewSession();
        Task<ResponseDto> ForgotPassword(string email);
        Task<ResponseDto> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
