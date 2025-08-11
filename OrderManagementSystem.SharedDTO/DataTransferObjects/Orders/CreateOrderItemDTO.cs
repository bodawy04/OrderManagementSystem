namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;

public class CreateOrderItemDTO
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; } = default!;
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
