using Domain.Models.Orders;

namespace Domain.Models.Invoices;

public class Invoice : BaseEntity<int>
{
    public int OrderId { get; set; } = default!;
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public Order Order { get; set; } = default!;
}