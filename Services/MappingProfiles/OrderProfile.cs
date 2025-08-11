namespace Services.MappingProfiles;

internal class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.PaymentMethod
            , opts => opts.MapFrom(src => src.PaymentMethod.ToString()))
            .ForMember(dest => dest.Status
            , opts => opts.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.OrderId, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.CustomerName, opts => opts.MapFrom(src => src.Customer.Name))
            .ReverseMap();

        CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.PaymentMethod
            , opts => opts.MapFrom(src => Enum.Parse<PaymentMethods>(src.PaymentMethod)))
            .ForMember(dest => dest.Status
            , opts => opts.MapFrom(src => Enum.Parse<Status>(src.Status)))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.CustomerId, opts => opts.MapFrom(src => src.CustomerId));

        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(dest => dest.OrderItemId, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.UnitPrice, opts => opts.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.ProductName, opts => opts.MapFrom(src => src.Product.Name))
            .ReverseMap();

        CreateMap<CreateOrderItemDTO, OrderItem>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.OrderItemId))
            .ForMember(dest => dest.UnitPrice, opts => opts.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.ProductId));
            
    }
}
