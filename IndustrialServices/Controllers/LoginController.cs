using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RedirectBasedOnRole(string role, string nama, int id)
        {
            HttpContext.Session.SetString("Role", role);
            HttpContext.Session.SetString("Nama", nama);
            HttpContext.Session.SetString("ID", id.ToString());
            return role switch
            {
                "Admin" => RedirectToAction("Index", "DashboardCRUD"),
                "Contributor" => RedirectToAction("Index", "DashboardContributor"),
                _ => RedirectToAction("Index", "Login"),
            };
        }
    }
}
