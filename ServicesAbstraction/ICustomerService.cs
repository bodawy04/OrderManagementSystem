using OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;

namespace ServicesAbstraction;

public  interface ICustomerService
{
    Task<IEnumerable<OrderDTO>> GetAllCustomerOrders(int id);
}
