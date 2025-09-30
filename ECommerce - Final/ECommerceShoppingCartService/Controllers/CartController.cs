using Microsoft.AspNetCore.Mvc;
using ECommerceShoppingCartService.Model;
namespace ECommerceShoppingCartService.Controllers;
using System.Text.Json;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{  
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name="AddToCart")]
    [Route("AddToCart")]
    public IActionResult AddToCart([FromQuery] string productId) {
        string json = null;
        json = HttpContext.Session.GetString("cart");
        if (json != null)
        {
            Cart theCart = JsonSerializer.Deserialize<Cart>(json);
            theCart.Items.Add(productId);
            json = JsonSerializer.Serialize(theCart);
        }
        else
        {
            Cart theCart = new Cart();
            theCart.Items.Add(productId);
            json = JsonSerializer.Serialize(theCart);
        }
        HttpContext.Session.SetString("cart", json);
        return Ok();
    }

    [HttpPost(Name="RemoveFromCart")]
    [Route("RemoveFromCart")]
    public IActionResult RemoveFromCart([FromQuery] string productId) {
        string json = null;
        json = HttpContext.Session.GetString("cart");
        if (json != null)
        {
            Cart existingCart = JsonSerializer.Deserialize<Cart>(json);
            existingCart.Items.Remove(productId);
            json = JsonSerializer.Serialize(existingCart);
            HttpContext.Session.SetString("cart", json);
        }
        return Ok();
    }

    [HttpGet(Name="ViewCart")]
    [Route("ViewCart")]
    public IActionResult ViewCart() {
        Cart existingCart = null;
        string json = null;
        json = HttpContext.Session.GetString("cart");
        if (json != null)
        {
            existingCart = JsonSerializer.Deserialize<Cart>(json);
        }
        return Ok(existingCart);
    }
}