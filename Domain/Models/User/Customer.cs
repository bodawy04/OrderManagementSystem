using Domain.Models.IdentityModule;
using Domain.Models.Orders;

namespace Domain.Models.User;

public class Customer : BaseEntity<int>
{
    public string UserId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
    public ICollection<Order> Orders { get; set; } = [];
}
