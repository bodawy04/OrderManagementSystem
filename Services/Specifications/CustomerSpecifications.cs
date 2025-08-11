using Domain.Models.User;

namespace Services.Specifications;

internal class CustomerSpecifications : BaseSpecifications<Customer>
{
    public CustomerSpecifications(string id)
        : base(c => c.UserId == id)
    {

    }
}