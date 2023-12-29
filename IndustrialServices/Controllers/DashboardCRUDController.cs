using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class DashboardCRUDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
