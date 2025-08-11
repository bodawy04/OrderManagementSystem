namespace Services.MappingProfiles;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDTO>()
            .ForMember(dest => dest.InvoiceId, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.InvoiceDate, opts => opts.MapFrom(src => DateOnly.FromDateTime(src.InvoiceDate)))
            .ReverseMap();
    }
}