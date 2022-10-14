using AutoMapper;
using Company.Product.Module.Dto.RelatedSample;

namespace Company.Product.Module.Domain.Mapping
{
    public class RelatedSampleProfile : Profile
    {
        public RelatedSampleProfile()
        {
            CreateMap<Entity.RelatedSample, RelatedSampleDto>()
                .ReverseMap();

            CreateMap<Entity.RelatedSample, CreateRelatedSampleDto>()
                .ReverseMap();

            CreateMap<Entity.RelatedSample, UpdateRelatedSampleDto>()
                .ReverseMap();

            CreateMap<Entity.RelatedSample, GetRelatedSampleDto>()
                .ReverseMap();

            CreateMap<Entity.RelatedSample, ListRelatedSampleDto>()
                .ReverseMap();

            CreateMap<Entity.RelatedSample, SearchRelatedSampleDto>()
                .ReverseMap();
        }
    }
}
