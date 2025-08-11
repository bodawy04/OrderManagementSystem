using Microsoft.AspNetCore.Authorization;
using OrderManagementSystem.SharedDTO.DataTransferObjects;
using OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;
using ServicesAbstractions;

namespace Presentation.Controllers;

[Authorize(Roles = "Admin")]
public class InvoicesController(IServiceManager serviceManager) : ApiController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<InvoiceDTO>> Get(int id)
    {
        var invoice = await serviceManager.InvoiceService.GetInvoiceByIdAsync(id);
        return Ok(invoice);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAll()
    {
        var invoices = await serviceManager.InvoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }
}