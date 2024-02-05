using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class PengelolaWebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
