using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.RestClient.Abstractions;
using $safesolutionname$.RestClient.Base;

namespace $safesolutionname$.RestClient.Implementation
{
    public class UserRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), IUserRestService
    {
        protected override string ApiController => "api/user";

        public async Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto)
            => await Post<CreateUserDto, ResponseDto<GetUserDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto)
            => await Put<UpdateUserDto, ResponseDto<GetUserDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete<ResponseDto>($"/{id}")!;

        public async Task<ResponseDto<GetUserDto>> Get(Guid id)
            => await Get<ResponseDto<GetUserDto>>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListUserDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListUserDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> filter)
            => await Post<SearchParamsDto<SearchUserFilterDto>, ResponseDto<SearchResultDto<SearchUserDto>>>("/search", filter)!;

        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await Post<LoginDto, ResponseDto<LoginResultDto>>("/login", loginDto)!;
    }
}
