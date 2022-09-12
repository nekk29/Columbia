using $safesolutionname$.RestClient.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Client
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
