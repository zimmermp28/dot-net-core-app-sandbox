using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sandbox.Models;

namespace Sandbox.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ReleaseOptions> _config;

        public HomeController(IOptions<ReleaseOptions> config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel { Title = "Sandbox", Release = _config.Value.Version };
            return View(homeViewModel);
        }

        public IActionResult About()
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
