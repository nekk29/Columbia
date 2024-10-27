using AutoMapper;
using $safesolutionname$.Dto.Action;

namespace $safesolutionname$.Domain.Mapping
{
    public class ActionProfile : Profile
    {
        public ActionProfile()
        {
            CreateMap<Entity.Action, ActionDto>()
                .ReverseMap();

            CreateMap<Entity.Action, CreateActionDto>()
                .ReverseMap();

            CreateMap<Entity.Action, UpdateActionDto>()
                .ReverseMap();

            CreateMap<Entity.Action, GetActionDto>()
                .ReverseMap();

            CreateMap<Entity.Action, ListActionDto>()
                .ReverseMap();

            CreateMap<Entity.Action, SearchActionDto>()
                .ReverseMap();
        }
    }
}
