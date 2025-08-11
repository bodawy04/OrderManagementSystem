namespace Services.Specifications;

internal class OrderSpecifications : BaseSpecifications<Order>
{
    public OrderSpecifications(int orderId)
        : base(order => order.Id == orderId)
    {
        AddInclude(o => o.Customer);
        AddInclude(o => o.OrderItems);
        //AddInclude(o => o.OrderItems.Select(oi => oi.Product));
    }
    public OrderSpecifications()
        : base(null)
    {
        AddInclude(o => o.Customer);
        AddInclude(o => o.OrderItems);
        //AddInclude(o => o.OrderItems.Select(oi => oi.Product));
    }
}