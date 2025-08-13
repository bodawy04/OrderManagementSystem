using Domain.Contracts;

namespace OrderManagementSystem.Extensions;

public static class WebApplicationRegistration
{
    public static async Task<WebApplication> InitializeDataBaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        await dbInitializer.InitializeAsync();
        await dbInitializer.InitializeIdentityAsync();
        return app;
    }

    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        return app;
    }
    public static IApplicationBuilder UseSwaggerMiddlewares(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }


}
