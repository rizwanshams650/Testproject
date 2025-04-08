using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Testproject.Models;

namespace Testproject.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult EnterValue()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterValue(UserInput input)
        {
            TempData["UserValue"] = input.Value;
            return RedirectToAction("DisplayValue");
        }

        public IActionResult DisplayValue()
        {
            ViewBag.UserValue = TempData["UserValue"];
            return View();
        }

    }
}
