namespace OrderManagementSystem.SharedDTO.DataTransferObjects;

public record InvoiceDTO
{
    public int InvoiceId { get; init; } = default!;
    public int OrderId { get; init; } = default!;
    public DateOnly InvoiceDate { get; init; }
    public decimal TotalAmount { get; init; }
}