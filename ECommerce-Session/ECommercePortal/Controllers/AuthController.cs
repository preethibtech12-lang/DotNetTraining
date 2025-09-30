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

    public IActionResult Login()
    {
        Claim theClaim = new Claim()
        {
            Email = "",
            Password = ""
        };
        return View(theClaim);
    }

    [HttpPost]
    public IActionResult Login(Claim theClaim)
    {
        if (theClaim.Email == "preethi@nihilent.com" &&
            theClaim.Password == "1234")
        {
            return RedirectToAction("index", "customers");
        }

        return View(theClaim);
    }


    public IActionResult Register()
    {
        Customer newCustomer = new Customer();
        newCustomer.OrgList = PopulateOrgs();
        return View(newCustomer);
    }

    [HttpPost]
    public IActionResult Register(Customer theCustomer, string[] organizations)
    {
        theCustomer.OrgList = PopulateOrgs();
        foreach (SelectListItem item in theCustomer.OrgList)
        {
            if (item != null)
            {
                if (organizations.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
        }
        return RedirectToAction("Index");
    }

    public static List<SelectListItem> PopulateOrgs()
    {
        List<SelectListItem> items = new List<SelectListItem>();
        items.Add(new SelectListItem { Text = "CDAC", Value = "CDAC", Selected = false });
        items.Add(new SelectListItem { Text = "IBM", Value = "IBM", Selected = false });
        items.Add(new SelectListItem { Text = "SEED", Value = "SEED", Selected = false });
        items.Add(new SelectListItem { Text = "Microsoft", Value = "Microsoft", Selected = false });
        items.Add(new SelectListItem { Text = "Google", Value = "Google", Selected = false });
        return items;
    }
}