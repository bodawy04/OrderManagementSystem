using OrderManagementSystem.SharedDTO;
using OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;

namespace ServicesAbstraction;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrders();
    Task<OrderDTO> GetOrderById(int orderId);
    Task<ResponseDTO> CreateOrder(CreateOrderDTO order, int id);
    Task<ResponseDTO> UpdateOrder(OrderDTO order,string status);
}
