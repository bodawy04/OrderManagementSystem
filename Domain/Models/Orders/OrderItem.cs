using Domain.Models.Products;
namespace Domain.Models.Orders;

public class OrderItem : BaseEntity<int>
{
    public int OrderId { get; set; } = default!;
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public Order Order { get; set; } = default!;
    public Product Product { get; set; } = default!;
}
