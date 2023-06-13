using AutoMapper;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Domain.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Entity.ApplicationRole, GetRoleDto>().ReverseMap();
            CreateMap<Entity.ApplicationRole, ListRoleDto>().ReverseMap();
            CreateMap<Entity.ApplicationRole, SearchRoleDto>().ReverseMap();
            CreateMap<Entity.ApplicationRole, CreateRoleDto>().ReverseMap();
            CreateMap<Entity.ApplicationRole, UpdateRoleDto>().ReverseMap();

            CreateMap<Entity.AspNetRole, GetRoleDto>().ReverseMap();
            CreateMap<Entity.AspNetRole, ListRoleDto>().ReverseMap();
            CreateMap<Entity.AspNetRole, SearchRoleDto>().ReverseMap();
            CreateMap<Entity.AspNetRole, CreateRoleDto>().ReverseMap();
            CreateMap<Entity.AspNetRole, UpdateRoleDto>().ReverseMap();
        }
    }
}
