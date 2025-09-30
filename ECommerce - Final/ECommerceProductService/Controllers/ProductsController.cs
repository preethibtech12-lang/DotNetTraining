using Microsoft.AspNetCore.Mvc;
using ECommerceProductService.Model;
using ECommerceProductService.Service;
namespace ECommerceProductService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{  
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    [Route("GetProductById")]
    public async Task<IActionResult> GetProductById(int id) {
        Product products = await _productService.GetProductById(id);
        return Ok(products);
    }

    [HttpGet]
    [Route("GetAllProducts")]
    public async Task<IActionResult> GetAllProduct() {
        IList<Product> products = await _productService.GetAllProduct();
        return Ok(products);
    }

    [HttpPost(Name="AddProduct")]
    [Route("AddProduct")]
    public IActionResult AddProduct([FromBody] Product product) {
        _productService.SaveProduct(product);
        return Ok();
    }

    [HttpPut(Name="UpdateProduct")]
    [Route("UpdateProduct")]
    public IActionResult UpdateProduct([FromBody] Product product){
        _productService.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete(Name="DeleteProduct")]
    [Route("DeleteProduct")]
    public IActionResult DeleteProduct(int ProductId){
        _productService.DeleteProduct(ProductId);
        return Ok();
    }
}
