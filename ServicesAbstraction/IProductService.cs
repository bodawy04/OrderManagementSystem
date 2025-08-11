using OrderManagementSystem.SharedDTO;
using Shared.DataTransferObjects.Products;

namespace ServicesAbstractions;

public interface IProductService
{
    Task<PaginatedResponse<ProductResponse>> GetAllProductsAsync(ProductQueryParameters queryParameters);
    Task<ProductResponse> GetProductByIdAsync(int id);
    Task<ResponseDTO> CreateProductAsync(ProductRequest product);
    Task<ResponseDTO> UpdateProductAsync(ProductRequest product);
}
