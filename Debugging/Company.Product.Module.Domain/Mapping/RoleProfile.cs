using AutoMapper;
using Company.Product.Module.Dto.Role;

namespace Company.Product.Module.Domain.Mapping
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

            CreateMap<Entity.AspNetRole, GetRoleDto>()
                .ForMember(m => m.ApplicationCode, opt => opt.MapFrom(m => m.Application != null ? m.Application.Code : null))
                .ForMember(m => m.ApplicationName, opt => opt.MapFrom(m => m.Application != null ? m.Application.Name : null))
                .ReverseMap();

            CreateMap<Entity.AspNetRole, ListRoleDto>()
                .ForMember(m => m.ApplicationCode, opt => opt.MapFrom(m => m.Application != null ? m.Application.Code : null))
                .ForMember(m => m.ApplicationName, opt => opt.MapFrom(m => m.Application != null ? m.Application.Name : null))
                .ReverseMap();

            CreateMap<Entity.AspNetRole, SearchRoleDto>()
                .ForMember(m => m.ApplicationCode, opt => opt.MapFrom(m => m.Application != null ? m.Application.Code : null))
                .ForMember(m => m.ApplicationName, opt => opt.MapFrom(m => m.Application != null ? m.Application.Name : null))
                .ReverseMap();

            CreateMap<Entity.AspNetRole, CreateRoleDto>().ReverseMap();
            CreateMap<Entity.AspNetRole, UpdateRoleDto>().ReverseMap();
        }
    }
}
