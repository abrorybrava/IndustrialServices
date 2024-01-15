using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class DashboardContributor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
