using Domain.Models.User;

namespace Services.MappingProfiles;

internal class CustomerProfile:Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
            .ReverseMap();
    }
}
