using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.RestClient.Base;

namespace Company.Product.Module.Client
{
    public class UserRestService : BaseService
    {
        protected override string ApiController => "api/user";

        public UserRestService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await Post<CreateUserDto, GetUserDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await Post<LoginDto, LoginResultDto>("/login", loginDto)!;
    }
}
