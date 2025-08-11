using OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;
namespace ServicesAbstractions;

public interface IAuthenticationService
{
    Task<UserDTO> LoginAsync(LoginDTO login);
    Task<UserDTO> RegisterAsync(RegisterDTO register);
    Task<bool> CheckEmailAsync(string email);
    //Task<UserResponse> GetUserByEmail(string email);
}
