using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.RestClient.Abstractions
{
    public interface IUserRestService
    {
        Task<ResponseDto<GetUserDto>> Create(CreateUserDto createDto);
        Task<ResponseDto<GetUserDto>> Update(UpdateUserDto updateDto);
        Task<ResponseDto> Delete(Guid id);
        Task<ResponseDto<GetUserDto>> Get(Guid id);
        Task<ResponseDto<IEnumerable<ListUserDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchUserDto>>> Search(SearchParamsDto<SearchUserFilterDto> filter);
        Task<ResponseDto<LoginResultDto>> Login(LoginDto loginDto);
    }
}
