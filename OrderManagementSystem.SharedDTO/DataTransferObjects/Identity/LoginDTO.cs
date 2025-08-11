namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;

public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
