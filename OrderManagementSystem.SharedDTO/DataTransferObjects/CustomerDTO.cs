namespace OrderManagementSystem.SharedDTO.DataTransferObjects;

public class CustomerDTO
{
    public int Id { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}
