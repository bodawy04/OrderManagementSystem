using System.Text.Json;
using System.Text.Json.Serialization;

namespace Persistence;

public class DbInitializer(UserManager<ApplicationUser> userManager
    , RoleManager<IdentityRole> roleManager, OrderIdentityDbContext context) : IDbInitializer
{
    public async Task InitializeAsync()
    {
        try
        {
            if (!context.Set<Product>().Any())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var data = await File.ReadAllTextAsync(@"..\Persistence\Data\Seeding\products.json");
                var objects = JsonSerializer.Deserialize<List<Product>>(data, options);
                if (objects is not null && objects.Any())
                {
                    context.Set<Product>().AddRange(objects);
                    await context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task InitializeIdentityAsync()
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            if (!userManager.Users.Any())
            {
                var Admin = new ApplicationUser
                {
                    UserName = "Admin1",
                    Email = "Admin.Support@gmail.com",
                };


                await userManager.CreateAsync(Admin, "Pa$$w0rd");

                await userManager.AddToRoleAsync(Admin, "Admin");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
