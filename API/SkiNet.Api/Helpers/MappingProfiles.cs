namespace SkiNet.Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductsToReturnDto>()
            .ForMember(dto => dto.ProductBrand, o => o
                .MapFrom(product => product.ProductBrand.BrandName))
            .ForMember(dto => dto.ProductType, o => o
                .MapFrom(product => product.ProductType.TypeName))
            .ForMember(dto => dto.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }
}
