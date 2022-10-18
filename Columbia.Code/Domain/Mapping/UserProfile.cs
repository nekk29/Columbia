using AutoMapper;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entity.ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Entity.ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<Entity.ApplicationUser, UpdateUserDto>().ReverseMap();
            CreateMap<Entity.ApplicationUser, GetUserDto>().ReverseMap();
            CreateMap<Entity.ApplicationUser, ListUserDto>().ReverseMap();
            CreateMap<Entity.ApplicationUser, SearchUserDto>().ReverseMap();

            CreateMap<Entity.AspNetUser, UserDto>().ReverseMap();
            CreateMap<Entity.AspNetUser, CreateUserDto>().ReverseMap();
            CreateMap<Entity.AspNetUser, UpdateUserDto>().ReverseMap();
            CreateMap<Entity.AspNetUser, GetUserDto>().ReverseMap();
            CreateMap<Entity.AspNetUser, ListUserDto>().ReverseMap();
            CreateMap<Entity.AspNetUser, SearchUserDto>().ReverseMap();
        }
    }
}
