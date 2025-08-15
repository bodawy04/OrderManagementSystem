using Domain.Contracts;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json;

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
        app.UseSwaggerUI(Options =>
        {
            Options.ConfigObject = new ConfigObject()
            {
                DisplayRequestDuration = true,
            };
            Options.DocumentTitle = "Order Management System API";
            Options.JsonSerializerOptions=new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            Options.DocExpansion(DocExpansion.None);
            Options.EnableFilter();
            Options.EnablePersistAuthorization();
            
        });
        return app;
    }
}
