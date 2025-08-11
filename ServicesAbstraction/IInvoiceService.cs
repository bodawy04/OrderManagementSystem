using OrderManagementSystem.SharedDTO.DataTransferObjects;

namespace ServicesAbstraction;

public interface IInvoiceService
{
    Task<InvoiceDTO> GetInvoiceByIdAsync(int id);
    Task<IEnumerable<InvoiceDTO>> GetAllInvoicesAsync();
}