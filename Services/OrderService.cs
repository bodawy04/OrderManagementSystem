using Domain.Models.User;
using OrderManagementSystem.SharedDTO;

namespace Services;

public class OrderService(IUnitOfWork unitOfWork, IMapper mapper) : IOrderService
{
    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        var orderSpecifications = new OrderSpecifications();
        var orders = await unitOfWork.GetRepository<Order, int>().GetAllAsync(orderSpecifications);
        return mapper.Map<IEnumerable<OrderDTO>>(orders);
    }
    public async Task<OrderDTO> GetOrderById(int orderId)
    {
        var orderSpecifications = new OrderSpecifications(orderId);
        var order = await unitOfWork.GetRepository<Order, int>().GetAsync(orderSpecifications)??
            throw new OrderNotFoundException(orderId);
        return mapper.Map<OrderDTO>(order);
    }
    public async Task<ResponseDTO> CreateOrder(CreateOrderDTO orderDto,int id)
    {
        decimal totalAmount = 0;
        foreach (var item in orderDto.OrderItems)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(item.ProductId) ??
                throw new ProductNotFoundException(item.ProductId);
            if (product.Stock < item.Quantity)
            {
                throw new Exception($"Insufficient stock for product '{product.Name}'. Available: {product.Stock}, Requested: {item.Quantity}");
            }
            else {
                product.Stock -= item.Quantity;
                unitOfWork.GetRepository<Product, int>().Update(product);
            }
            item.UnitPrice = product.Price;
            totalAmount += (item.Quantity * item.UnitPrice) * (1-item.Discount);
        }

        if (totalAmount > 200)
            totalAmount -= (totalAmount * 0.10m);
        else if (totalAmount > 100)
            totalAmount -= (totalAmount * 0.05m);

        orderDto.TotalAmount = totalAmount;
        
        orderDto.CustomerId = id;

        var order = mapper.Map<Order>(orderDto);

        order.Invoice = new Invoice
        {
            TotalAmount = totalAmount,
            InvoiceDate = DateTime.Now
        };

        unitOfWork.GetRepository<Order, int>().Add(order);
        int result = await unitOfWork.SaveChangesAsync();
        return result > 0 ?
            new ResponseDTO{ StatusCode = 200, Message = "Order Placed Successfully"} 
            : throw new Exception("Couldn't Place Order");
    }
    public async Task<ResponseDTO> UpdateOrder(OrderDTO orderDto,string status)
    {
        orderDto.Status = status;
        var order = mapper.Map<Order>(orderDto);
        order.Customer = null!;
        unitOfWork.GetRepository<Order, int>().Update(order);
        int result = await unitOfWork.SaveChangesAsync();
        return result > 0 ?
            new ResponseDTO { StatusCode = 200, Message = "Order Updated Successfully" } 
            : throw new Exception("Couldn't Update Order");
    }
}
