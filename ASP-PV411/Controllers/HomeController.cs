using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_PV411.Models.Home;
using ASP_PV411.Models;

namespace ASP_PV411.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Intro()
    {   
        return View();
    }

    public IActionResult Razor()
    {
        ViewBag.arr1 = new String[] { "string 1", "string 2" };

        ViewData["arr2"] = new String[] { "string 3", "string 4" };

        HomeRazorViewModel model = new()
        {
            Products = [
                    new() { Name = "Asus",   Price = 18900 },
                    new() { Name = "Lenovo", Price = 19800 },
                    new() { Name = "Acer",   Price = 21000 },
                    new() { Name = "Dell",   Price = 25000 },
                    new() { Name = "HP",     Price = 15200 },
                ]
        };
        return View(model);
    }

    public IActionResult History()
    {
        return View();
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
