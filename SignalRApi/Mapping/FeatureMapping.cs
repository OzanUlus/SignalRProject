using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Slider, ResultFeatureDto>().ReverseMap();
            CreateMap<Slider, CreateFeatureDto>().ReverseMap();
            CreateMap<Slider, UpdateFeatureDto>().ReverseMap();
            CreateMap<Slider, ListFeatureDto>().ReverseMap();
        }
    }
}
