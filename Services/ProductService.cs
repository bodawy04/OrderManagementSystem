using OrderManagementSystem.SharedDTO;

namespace Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<ResponseDTO> CreateProductAsync(ProductRequest productReq)
    {
        var product = mapper.Map<ProductRequest, Product>(productReq);
        unitOfWork.GetRepository<Product, int>().Add(product);
        var result = await unitOfWork.SaveChangesAsync();
        return result > 0 ?
            new ResponseDTO { StatusCode = 200, Message = "Product Created Successfully" }
           : throw new Exception("Couldn't Add The Product");
    }

    public async Task<PaginatedResponse<ProductResponse>> GetAllProductsAsync(ProductQueryParameters queryParameters)
    {
        var specifications = new ProductSpecifications(queryParameters);
        var product = await unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
        var data = mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(product);
        var totalCount = await unitOfWork.GetRepository<Product, int>()
            .CountAsync(new ProductsCountSpecifications(queryParameters));
        return new(queryParameters.PageSize, queryParameters.PageIndex, totalCount, data);
    }
    public async Task<ProductResponse> GetProductByIdAsync(int id)
    {
        var specifications = new ProductSpecifications(id);
        var product = await unitOfWork.GetRepository<Product, int>().GetAsync(specifications)
            ?? throw new ProductNotFoundException(id);
        return mapper.Map<Product, ProductResponse>(product);
    }

    public async Task<ResponseDTO> UpdateProductAsync(ProductRequest productReq)
    {
        var product = await unitOfWork.GetRepository<Product, int>().GetAsync(productReq.Id)
            ?? throw new ProductNotFoundException(productReq.Id);
        mapper.Map(productReq, product);
        unitOfWork.GetRepository<Product, int>().Update(product);

        var result = await unitOfWork.SaveChangesAsync();
        return result == 1 ? 
            new ResponseDTO { StatusCode = 200, Message = "Product Updated Successfully" }
            : throw new Exception("Couldn't Update The Product");
    }
}
