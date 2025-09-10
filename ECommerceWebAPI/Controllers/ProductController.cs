using Microsoft.AspNetCore.Mvc;
using ECommerceDomain;
using System.Linq;
using ECommerceServices;
namespace ECommerceWebAPI.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController (IProductService productService, ILogger<ProductController> _logger) : ControllerBase 
{
    [HttpGet(Name = "GetAllProducts")]
    [Route("GetAllProduct")]
    public IActionResult Get()
    {
        IList<Product> products = productService.Get();
        return Ok(products);
    }

    [HttpGet(Name = "GetProductById")]
    [Route("GetProductById")]
    public IActionResult Get(int ProductId)
    {
        Product product = productService.Get(ProductId);
        return Ok(product);
    }    
}
