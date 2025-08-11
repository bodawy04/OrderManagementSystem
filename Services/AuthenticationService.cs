using Domain.Models.User;
using Microsoft.IdentityModel.Tokens;
using OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services;

internal class AuthenticationService(UserManager<ApplicationUser> userManager,
    IConfiguration configuration, IUnitOfWork unitOfWork) : IAuthenticationService
{
    public async Task<bool> CheckEmailAsync(string email)
    => (await userManager.FindByEmailAsync(email)) != null;

    public Task<IEnumerable<CustomerDTO>> GetAllUserOrdersAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO> LoginAsync(LoginDTO login)
    {
        var user = await userManager.FindByEmailAsync(login.Email) ??
            throw new UserNotFoundException(login.Email);

        var isValid = await userManager.CheckPasswordAsync(user, login.Password);
        var role = await userManager.GetRolesAsync(user);

        if (isValid)
        {
            var id = -1;
            if (role[0]=="Customer"){
            var customerSpecifications = new CustomerSpecifications(user.Id);
            var customer = await unitOfWork.GetRepository<Customer, int>()
                    .GetAsync(customerSpecifications);
            id=customer!.Id;
            }
            return new UserDTO()
            { Email = user.Email!, UserName = user.UserName!, Token = await CreateTokenAsync(user, configuration, id) };
        }
        else throw new UnauthorizedException();
    }

    public async Task<UserDTO> RegisterAsync(RegisterDTO register)
    {
        var user = new ApplicationUser
        {
            Email = register.Email,
            UserName = register.UserName,
        };
        var result = await userManager.CreateAsync(user, register.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRolesAsync(user, ["Customer"]);

            unitOfWork.GetRepository<Customer, int>().Add(new Customer
            { Email = register.Email, UserId = user.Id, Name = register.UserName }
            );
            return await unitOfWork.SaveChangesAsync() == 1 ? new()
            {
                Email = register.Email,
                UserName = user.UserName,
                Token = await CreateTokenAsync(user, configuration, 0)
            } : throw new Exception("Can't Create User At the Moment");
        }
        var errors = result.Errors.Select(e => e.Description).ToList();

        throw new BadRequestException(errors);
    }

    private async Task<string> CreateTokenAsync(ApplicationUser user, IConfiguration _configuration, int id)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.Name, user.UserName!),
            new("CustomerId", $"{id}"),
        };
        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var SecretKey = _configuration.GetSection("JWTOptions")["SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration.GetSection("JWTOptions")["Issuer"],
            audience: _configuration.GetSection("JWTOptions")["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}
