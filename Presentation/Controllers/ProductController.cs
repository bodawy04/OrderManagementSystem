using Microsoft.AspNetCore.Authorization;
using OrderManagementSystem.SharedDTO;
using Presentation.Controllers;
using ServicesAbstractions;
using Shared.DataTransferObjects.Products;

public class ProductsController(IServiceManager serviceManager) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<ProductResponse>>> GetAllProducts([FromQuery] ProductQueryParameters queryParameters)
    {
        var products = await serviceManager.ProductService.GetAllProductsAsync(queryParameters);
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(int id)
    {
        var product = await serviceManager.ProductService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<ResponseDTO>> AddProduct([FromBody] ProductRequest productReq)
    {
        var product = await serviceManager.ProductService.CreateProductAsync(productReq);
        return Ok(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseDTO>> UpdateProduct(int id, [FromBody] ProductRequest productReq)
    {

        var updatedProduct =
        await serviceManager.ProductService.UpdateProductAsync(new ProductRequest
        {
            Id = id,
            Name = productReq.Name,
            Price = productReq.Price,
            Stock = productReq.Stock,
        });
        return Ok(updatedProduct);
    }
}