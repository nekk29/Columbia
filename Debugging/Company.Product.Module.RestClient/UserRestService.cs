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

        public async Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto)
            => await Put<UpdateUserDto, GetUserDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetUserDto>> Get(Guid id)
            => await Get<GetUserDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListUserDto>>> List()
            => await Get<IEnumerable<ListUserDto>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> filter)
            => await Post<SearchParamsDto<SearchUserFilterDto>, SearchResultDto<SearchUserDto>>("/search", filter)!;

        public async Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto)
            => await Post<LoginDto, LoginResultDto>("/login", loginDto)!;
    }
}
