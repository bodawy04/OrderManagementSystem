using OrderManagementSystem.Extensions;
using Persistence;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerServices();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebApplicationServices();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

await app.InitializeDataBaseAsync();

app.UseCustomExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerMiddlewares();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
