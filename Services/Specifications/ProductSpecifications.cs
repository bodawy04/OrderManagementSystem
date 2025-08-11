namespace Services.Specifications;

internal class ProductSpecifications : BaseSpecifications<Product>
{
    public ProductSpecifications(ProductQueryParameters parameters)
        : base(product =>
        (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower()))
        )
    {
        ApplyPagination(parameters.PageSize, parameters.PageIndex);
        switch (parameters.Options)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDescending(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDescending(p => p.Price);
                break;
            default:
                break;

        }
    }

    public ProductSpecifications(int id)
        : base(product => product.Id == id)
    {

    }
}
