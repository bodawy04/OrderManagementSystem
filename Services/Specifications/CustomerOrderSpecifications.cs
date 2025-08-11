namespace Services.Specifications;

internal class CustomerOrderSpecifications : BaseSpecifications<Order>
{
    public CustomerOrderSpecifications(int customerId)
        : base(o => o.CustomerId == customerId)
    {
        AddInclude(o => o.Customer);
        AddInclude(o => o.OrderItems);
    }
}