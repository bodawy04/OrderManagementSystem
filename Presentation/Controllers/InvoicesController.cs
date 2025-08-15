using Microsoft.AspNetCore.Authorization;
using OrderManagementSystem.SharedDTO.DataTransferObjects;
using Presentation.Attributes;
using ServicesAbstractions;

namespace Presentation.Controllers;

[Authorize(Roles = "Admin")]
public class InvoicesController(IServiceManager serviceManager) : ApiController
{
    [HttpGet("{id}")]
    [Cache(30)]
    public async Task<ActionResult<InvoiceDTO>> Get(int id)
    {
        var invoice = await serviceManager.InvoiceService.GetInvoiceByIdAsync(id);
        return Ok(invoice);
    }
    [HttpGet]
    [Cache(30)]
    public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAll()
    {
        var invoices = await serviceManager.InvoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }
}