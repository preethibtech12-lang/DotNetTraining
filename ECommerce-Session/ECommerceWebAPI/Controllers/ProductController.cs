using Microsoft.AspNetCore.Mvc;
using ECommerceDomain;
using System.Linq;
using ECommerceServices;
namespace ECommerceWebAPI.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController (IProductService _productService, ILogger<ProductController> _logger) : ControllerBase 
{
    [HttpGet(Name = "GetAllProducts")]
    [Route("GetAllProduct")]
    public IActionResult Get()
    {
        IList<Product> products = _productService.Get();
        return Ok(products);
    }

    [HttpGet(Name = "GetProductById")]
    [Route("GetProductById")]
    public IActionResult Get(int ProductId)
    {
        Product product = _productService.Get(ProductId);
        return Ok(product);
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
