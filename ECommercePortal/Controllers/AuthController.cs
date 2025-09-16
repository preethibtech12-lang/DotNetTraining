using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommercePortal.Models;
using ECommerceServices;
using ECommerceDomain;
using System.Linq;

namespace ECommercePortal.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;
    public AuthController(ILogger<AuthController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Login() {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password) {
        if(username != null && password != null) {
            if(IsCheckUserExist(username, password)) {
                return RedirectToAction("Product", "Product");
            }
        }
        ViewBag.ErrorMsg = "Please enter valid UserName and Password"; 
        return View();
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user) {
        // if (ModelState.IsValid)
        // {
            _userService.AddUser(user);
        //}  
        return RedirectToAction("Login", "Auth");
    }

    public bool IsCheckUserExist(string username, string password) {
       IList<User> userList =  _userService.GetAllUser();
       return userList.Any(u => u.EmailId == username && u.Password == password);        
    }
}