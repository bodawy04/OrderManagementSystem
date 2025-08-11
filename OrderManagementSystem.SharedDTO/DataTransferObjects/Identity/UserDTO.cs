namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;

public class UserDTO
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Token{ get; set; } = default!;
}
