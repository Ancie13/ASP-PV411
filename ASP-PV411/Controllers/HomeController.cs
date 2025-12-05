using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_PV411.Models.Home;
using ASP_PV411.Services.Hash;
using ASP_PV411.Services.Kdf;
using ASP_PV411.Services.Random;
using ASP_PV411.Services.Salt;
using ASP_PV411.Services.Signature;
using ASP_PV411.Services.Timestamp;
using ASP_PV411.Models;
using ASP_PV411.Services.OTP;
using ASP_PV411.Services.Rfn;

namespace ASP_PV411.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRandomService _randomService;
    private readonly ITimestampService _timestampService;
    private readonly IHashService _hashService;
    private readonly ISaltService _saltService;
    private readonly IKdfService _kdfService;
    private readonly ISignatureService _signatureService;
    private readonly IOtpService _otpService;
    private readonly IRfnService _rfnService;


    public HomeController(ILogger<HomeController> logger, IRandomService randomService, ITimestampService timestampService, IHashService hashService, ISaltService saltService, IKdfService kdfService, ISignatureService signatureService, IOtpService otpService, IRfnService rfnService)
    {
        _logger = logger;
        _randomService = randomService;
        _timestampService = timestampService;
        _hashService = hashService;
        _saltService = saltService;
        _kdfService = kdfService;
        _signatureService = signatureService;
        _otpService = otpService;
        _rfnService = rfnService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult IoC()
    {
        HomeIocViewModel model = new ()
        {
            RandomValue = _randomService.RandomInt(),
            RandomServiceHashCode = _randomService.GetHashCode()
        };
        ViewData["ctrl"] = _timestampService.Timestamp();
        ViewData["sign"] = _signatureService.Sign("123", "456");
        ViewData["hash"] = _hashService.Digest("123");
        ViewData["salt"] = _saltService.GetSalt() + " " + _saltService.GetSalt(8);
        ViewData["dk"] = _kdfService.Dk("123", "456");
        ViewData["otp"] = _otpService.GetOtp(5);
        ViewData["rfn"] = _rfnService.GetRfn(16);
        return View(model);
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
