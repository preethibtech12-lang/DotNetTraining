using Microsoft.AspNetCore.Mvc;
using ECommerceDomain;

namespace ECommerceWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProduct")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
        {
            Name = "HP Laptop",
            Description = "HP Laptop Description"      
        })
        .ToArray();
    }
}
