namespace Services.Specifications;

internal class ProductsCountSpecifications(ProductQueryParameters parameters)
        : BaseSpecifications<Product>(CreateCriteria(parameters))
{
    public static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return product =>
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower()));
    }
}

