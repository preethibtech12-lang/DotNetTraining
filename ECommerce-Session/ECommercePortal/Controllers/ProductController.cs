using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommercePortal.Models;
using ECommerceServices;
using ECommerceDomain;

namespace ECommercePortal.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Home()
    {       
        return View();
    }
    public IActionResult Product()
    {
         IList<Product> products = _productService.Get();
        return View(products);
    }
    public IActionResult ProductDetails(int id)
    {
        Product product = _productService.Get(id);
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
