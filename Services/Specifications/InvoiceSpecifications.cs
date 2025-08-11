namespace Services.Specifications;

internal class InvoiceSpecifications : BaseSpecifications<Invoice>
{
    public InvoiceSpecifications(int invoiceId)
        : base(i => i.Id == invoiceId)
    {
        AddInclude(i => i.Order);
    }

    public InvoiceSpecifications()
        : base(null)
    {
        AddInclude(i => i.Order);
    }
}