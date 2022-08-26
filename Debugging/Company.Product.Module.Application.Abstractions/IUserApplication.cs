using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Application.Abstractions
{
    public interface IUserApplication
    {
        Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto);
        Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto);
    }
}
