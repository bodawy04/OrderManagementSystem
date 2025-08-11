using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
        return services;
    }
}
