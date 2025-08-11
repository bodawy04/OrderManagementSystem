namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;

public class RegisterDTO
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
