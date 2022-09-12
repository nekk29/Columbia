using AutoMapper;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.Domain.Mapping.Sample
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<Entity.Sample, SampleDto>()
                .ReverseMap();

            CreateMap<Entity.Sample, CreateSampleDto>()
                .ReverseMap();

            CreateMap<Entity.Sample, UpdateSampleDto>()
                .ReverseMap();

            CreateMap<Entity.Sample, GetSampleDto>()
                .ReverseMap();

            CreateMap<Entity.Sample, ListSampleDto>()
                .ReverseMap();

            CreateMap<Entity.Sample, SearchSampleDto>()
                .ReverseMap();
        }
    }
}
