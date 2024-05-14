using AutoMapper;
using SignalR.DtoLayer.ProductDto;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductMapping , ResultProductDto>().ReverseMap();
            CreateMap<ProductMapping , CreateProductDto>().ReverseMap();
            CreateMap<ProductMapping , UpdateProductDto>().ReverseMap();
            CreateMap<ProductMapping , ListProductDto>().ReverseMap();
            CreateMap<ProductMapping , ResultProductWithCategory>().ReverseMap();
        }
    }
}
