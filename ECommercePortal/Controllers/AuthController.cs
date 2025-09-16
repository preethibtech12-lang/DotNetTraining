using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommercePortal.Models;
using ECommerceServices;
using ECommerceDomain;

namespace ECommercePortal.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;
    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public IActionResult Login() {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password) {

        if(username != null && password != null){
            this.Response.RedirectUrl("Product/Product");
        } 
        return View();
    }
}