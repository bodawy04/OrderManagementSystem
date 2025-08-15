using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IServiceManager, ServiceManagerWithFactoryDelegate>();
        services.AddScoped<ICacheService,CacheService>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<Func<IProductService>>(provider=>provider.GetRequiredService<IProductService>);

        services.AddScoped<IAuthenticationService,AuthenticationService>();
        services.AddScoped<Func<IAuthenticationService>>(provider=>provider.GetRequiredService<IAuthenticationService>);

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<Func<IOrderService>>(provider=>provider.GetRequiredService<IOrderService>);

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<Func<ICustomerService>>(provider=>provider.GetRequiredService<ICustomerService>);

        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<Func<IInvoiceService>>(provider=>provider.GetRequiredService<IInvoiceService>);

        services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
        return services;
    }
}
