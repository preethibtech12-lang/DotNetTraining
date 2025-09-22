using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
using System.Security.Claims;
using StateManagement.Services;

namespace StateManagement.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = _userService.Validate(email,password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, email)
            };
            var claimsIdentity = new ClaimsIdentity(claims, 
                                                    CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                            claimsPrincipal);
            return RedirectToAction("Welcome", "Home");
        }
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
    public IActionResult AccessDenied()
    {
        return View();
    }

}
    

