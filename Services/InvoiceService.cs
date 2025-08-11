namespace Services;

public class InvoiceService(IUnitOfWork unitOfWork, IMapper mapper) : IInvoiceService
{
    public async Task<IEnumerable<InvoiceDTO>> GetAllInvoicesAsync()
    {
        var specifications = new InvoiceSpecifications();
        var invoice = await unitOfWork.GetRepository<Invoice, int>().GetAllAsync(specifications);
        return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceDTO>>(invoice);
    }

    public async Task<InvoiceDTO> GetInvoiceByIdAsync(int id)
    {
        var specifications = new InvoiceSpecifications(id);
        var invoice = await unitOfWork.GetRepository<Invoice, int>().GetAsync(specifications)
            ?? throw new InvoiceNotFoundException(id);
        return mapper.Map<Invoice, InvoiceDTO>(invoice);
    }
}