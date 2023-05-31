using AutoMapper;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Mapping
{
    public class SettingProfile : Profile
    {
        public SettingProfile()
        {
            CreateMap<Entity.Setting, SettingDto>()
                .ReverseMap();

            CreateMap<Entity.Setting, UpdateSettingDto>()
                .ReverseMap();

            CreateMap<Entity.Setting, GetSettingDto>()
                .ReverseMap();

            CreateMap<Entity.Setting, SearchSettingDto>()
                .ReverseMap();
        }
    }
}
