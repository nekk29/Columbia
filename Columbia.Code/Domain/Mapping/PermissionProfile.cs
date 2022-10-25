using AutoMapper;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Domain.Mapping
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Entity.Permission, ListPermissionDto>()
                .ForMember(m => m.RoleName, opt => opt.MapFrom(m => m.Role!.Name))
                .ForMember(m => m.ActionCode, opt => opt.MapFrom(m => m.Action!.Code))
                .ForMember(m => m.ActionName, opt => opt.MapFrom(m => m.Action!.Name))
                .ReverseMap()
                .ForMember(m => m.RoleId, opt => opt.MapFrom(m => m.RoleId));
        }
    }
}
