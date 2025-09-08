using Microsoft.AspNetCore.Mvc;
using ECommerceDomain;
using System.Linq;
using ECommerceServices;
namespace ECommerceWebAPI.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet(Name = "GetAllProduct")]
    [Route("GetAllProduct")]
    public IActionResult Get()
    {
        IList<Product> products = _productService.Get();
        return Ok(products);
    }

    [HttpGet(Name = "GetProductById")]
    [Route("GetProductById")]
    public IEnumerable<Product> Get(int ProductId)
    {
        var productList = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                Name = "HP Laptop",
                Description = "HP Laptop Description"
            },
            new Product
            {
                ProductId = 2,
                Name = "Dell Laptop",
                Description = "Dell Laptop Description"
            },
            new Product
            {
                ProductId = 3,
                Name = "Mac Book",
                Description = "Mac Book Description"
            }
        };
        var product = productList.Where(p=> p.ProductId == 3);
        return product;
    }    
}
