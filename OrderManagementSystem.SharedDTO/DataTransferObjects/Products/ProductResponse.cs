namespace Shared.DataTransferObjects.Products;

public record ProductResponse
{
    public int Id { get; init; }
    public string Name { get; init; } =default!;
    public decimal Price { get; init; }
    public int Stock { get; init; }
}
