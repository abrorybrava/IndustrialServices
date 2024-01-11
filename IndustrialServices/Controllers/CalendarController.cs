using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
