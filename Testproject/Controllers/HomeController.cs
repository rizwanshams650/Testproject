using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Testproject.Models;
using Testproject.Services;

namespace Testproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostService _postService;

        public HomeController(ILogger<HomeController> logger, PostService postService)
        {
            _logger = logger;
            _postService = postService;
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
            _logger.LogInformation("Get EnterValue at {Time}", DateTime.UtcNow);

            return View();
        }
        [HttpPost]
        public IActionResult EnterValue(UserInput input)
        {
            _logger.LogInformation("Post EnterValue called with user input:{Value} at {Time}", input.Value, DateTime.UtcNow);
            TempData["UserValue"] = input.Value;
            return RedirectToAction("DisplayValue");
        }

        public IActionResult DisplayValue()
        {
            var value = TempData["UserValue"];
            ViewBag.UserValue = value;
            _logger.LogInformation("DisplayValue called with TempData value: {Value}", value);

            return View();
        }

        public async Task<IActionResult> ShowPosts()
        {
            var posts = await _postService.GetPostsAsyncs();
            return View(posts);
        }

    }
}
