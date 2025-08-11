using ServicesAbstraction;

namespace ServicesAbstractions;

public interface IServiceManager
{
    IProductService ProductService { get; }
    IAuthenticationService AuthenticationService { get; }
    IOrderService OrderService { get; }
    ICustomerService CustomerService { get; }
    IInvoiceService InvoiceService { get; }
}
