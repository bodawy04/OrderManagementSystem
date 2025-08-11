namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;

public class OrderDTO
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = default!;
    public DateOnly OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public IEnumerable<OrderItemDTO> OrderItems { get; set; } = [];
    public string PaymentMethod { get; set; } = "Cash";
    public string Status { get; set; } = "Pending";
}

