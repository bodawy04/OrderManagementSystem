using Domain.Models.Orders;

namespace Domain.Models.Products;

public class Product : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
