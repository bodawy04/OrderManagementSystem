namespace Services;

public class CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : ICustomerService
{
    public async Task<IEnumerable<OrderDTO>> GetAllCustomerOrders(int id)
    {
        var orderSpecifications = new CustomerOrderSpecifications(id);
        var orders = await unitOfWork.GetRepository<Order, int>().GetAllAsync(orderSpecifications);
        return orders.Count() == 0 ? throw new Exception("No Orders for this customer")
            : mapper.Map<IEnumerable<OrderDTO>>(orders);
    }
}
