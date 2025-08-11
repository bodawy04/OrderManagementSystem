namespace Services.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>().ReverseMap();
        CreateMap<Product, ProductRequest>().ReverseMap();
    }
}
