namespace Services;

public class ServiceManager(IMapper mapper, IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager, IConfiguration configuration)

{
    private readonly Lazy<IProductService> _lazyProductService =
        new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
    public IProductService ProductService => _lazyProductService.Value;


    private readonly Lazy<IAuthenticationService> _lazyAuthenticationService =
        new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, configuration, unitOfWork));

    public IAuthenticationService AuthenticationService => _lazyAuthenticationService.Value;

    private readonly Lazy<IOrderService> _lazyOrderService =
        new Lazy<IOrderService>(() => new OrderService(unitOfWork, mapper));

    public IOrderService OrderService => _lazyOrderService.Value;

    private readonly Lazy<ICustomerService> _lazyCustomerService =
    new Lazy<ICustomerService>(() => new CustomerService(unitOfWork, mapper));
    public ICustomerService CustomerService => _lazyCustomerService.Value;

    private readonly Lazy<IInvoiceService> _lazyInvoiceService =
    new Lazy<IInvoiceService>(() => new InvoiceService(unitOfWork, mapper));
    public IInvoiceService InvoiceService => _lazyInvoiceService.Value;
}
