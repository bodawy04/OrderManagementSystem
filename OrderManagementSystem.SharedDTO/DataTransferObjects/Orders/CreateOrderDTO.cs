namespace OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;

public class CreateOrderDTO
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public decimal TotalAmount { get; set; }
    public IEnumerable<CreateOrderItemDTO> OrderItems { get; set; } = [];
    public string PaymentMethod { get; set; } = "Cash";
    public string Status { get; set; } = "Pending";
}

