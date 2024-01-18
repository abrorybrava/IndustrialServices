using IndustrialServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IndustrialServices.Controllers
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
        public IActionResult FacultyMember()
        {
            return View();
        }
        public IActionResult Fasilitas()
        {
            return View();
        }
        public IActionResult Produk()
        {
            return View();
        }
        public IActionResult Pelatihan()
        {
            return View();
        }
        public IActionResult KalenderTechnical()
        {
            return View();
        }
        public IActionResult KalenderNonTechnical()
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
}