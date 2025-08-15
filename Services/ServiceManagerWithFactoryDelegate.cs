
namespace Services;

public class ServiceManagerWithFactoryDelegate(
    Func<IProductService> ProductFactory,
    Func<IAuthenticationService> AuthenticationFactory,
    Func<IOrderService> OrderFactory,
    Func<ICustomerService> CustomerFactory,
    Func<IInvoiceService> InvoiceFactory
    ) : IServiceManager
{
    public IProductService ProductService => ProductFactory.Invoke();

    public IAuthenticationService AuthenticationService => AuthenticationFactory.Invoke();
    public IOrderService OrderService => OrderFactory.Invoke();
    public ICustomerService CustomerService => CustomerFactory.Invoke();
    public IInvoiceService InvoiceService => InvoiceFactory.Invoke();
}
