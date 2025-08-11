using Microsoft.AspNetCore.Authorization;
using OrderManagementSystem.SharedDTO;
using OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;
using ServicesAbstractions;

namespace Presentation.Controllers;

public class OrdersController(IServiceManager serviceManager) : ApiController
{
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDTO>> Get(int id)
    {
        var order = await serviceManager.OrderService.GetOrderById(id);
        return Ok(order);
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ResponseDTO>> Create([FromBody]CreateOrderDTO orderDto)
    {
        int customerId = int.Parse(User.FindFirst("CustomerId")?.Value!);
        var order = await serviceManager.OrderService.CreateOrder(orderDto, customerId);
        return Ok(order);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
    {
        var orders = await serviceManager.OrderService.GetAllOrders();
        return Ok(orders);
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/{status}")]
    public async Task<ActionResult<ResponseDTO>> UpdateOrder(int id, string status)
    {
        var order = await serviceManager.OrderService.GetOrderById(id);
        var updatedOrder = await serviceManager.OrderService.UpdateOrder(order, status);
        return Ok(updatedOrder);
    }
}