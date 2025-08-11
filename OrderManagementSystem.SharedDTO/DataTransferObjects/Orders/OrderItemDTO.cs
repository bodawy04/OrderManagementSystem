namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;

public class OrderItemDTO
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; } = default!;
    //public int ProductId { get; set; }
    public string ProductName { get; set; }=default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
