using System.Diagnostics;
using GuidGenerator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuidGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        public const string GuidsViewDataKey = "GuidsViewData";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData[GuidsViewDataKey] = new List<Guid>() { Guid.NewGuid() };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int guidAmount)
        {
            var guids = new List<Guid>();
            for(var i = 0; i < guidAmount; i++)
                guids.Add(Guid.NewGuid());

            ViewData[GuidsViewDataKey] = guids;

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
}