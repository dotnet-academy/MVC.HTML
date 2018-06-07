using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ViewSamples.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Count = 5;
            ViewData["NumTimes"] = 2;

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
