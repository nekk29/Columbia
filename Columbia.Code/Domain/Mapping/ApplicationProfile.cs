using AutoMapper;
using $safesolutionname$.Dto.Application;

namespace $safesolutionname$.Domain.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Entity.Application, ApplicationDto>()
                .ReverseMap();

            CreateMap<Entity.Application, CreateApplicationDto>()
                .ReverseMap();

            CreateMap<Entity.Application, UpdateApplicationDto>()
                .ReverseMap();

            CreateMap<Entity.Application, GetApplicationDto>()
                .ReverseMap();

            CreateMap<Entity.Application, ListApplicationDto>()
                .ReverseMap();

            CreateMap<Entity.Application, SearchApplicationDto>()
                .ReverseMap();
        }
    }
}
