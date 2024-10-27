using AutoMapper;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Mapping
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

            CreateMap<Entity.Setting, ListSettingDto>()
                .ReverseMap();

            CreateMap<Entity.Setting, SearchSettingDto>()
                .ReverseMap();
        }
    }
}
