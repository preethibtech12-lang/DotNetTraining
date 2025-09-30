using Microsoft.AspNetCore.Mvc;
using ECommerceOrderProcessingService.Model;
using ECommerceOrderProcessingService.Service;
namespace ECommerceOrderProcessingService.Controllers;

[ApiController]
[Route("api/order")]
public class OrderProcessingController : ControllerBase
{  
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderProcessingController> _logger;

    public OrderProcessingController(ILogger<OrderProcessingController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost(Name="SaveOrder")]
    [Route("SaveOrder")]
    public IActionResult PlaceOrder([FromBody] Order order) {
        _orderService.SaveOrder(order);
        return Ok(order);
    }

    [HttpGet(Name="GetOrder")]
    [Route("GetOrder")]
    public IActionResult GetOrderByUserId([FromQuery] string userId) {
        IList<Order> orders = _orderService.GetOrderByUserId(userId);
        return Ok(orders);
    }
}    