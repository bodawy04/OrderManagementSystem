using Microsoft.AspNetCore.Authorization;
using OrderManagementSystem.SharedDTO.DataTransferObjects.Orders;
using ServicesAbstractions;

namespace Presentation.Controllers;

public class CustomersController(IServiceManager serviceManager):ApiController
{
    [Authorize]
    [HttpGet("{id}/orders")]
    public async Task<ActionResult<OrderDTO>> GetCustomerOrders(int id)
    {
        var orders = await serviceManager.CustomerService.GetAllCustomerOrders(id);
        return Ok(orders);
    }
}
