using Microsoft.AspNetCore.Mvc;
using ECommerceUserService.Models;
using ECommerceUserService.Services;
using System.Text.Json;
namespace ECommerceUserService.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        Console.WriteLine( "controller: "+ JsonSerializer.Serialize(model));
        var response = await _userService.Authenticate(model);
        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });
        return Ok(response);
    }
}
