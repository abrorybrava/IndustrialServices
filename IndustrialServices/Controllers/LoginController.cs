using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IndustrialServices.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Serializable]
        public class SerializedModel
        {
            public string Role { get; set; }
            public string Nama { get; set; }
            public int ID { get; set; }
        }
        public IActionResult RedirectBasedOnRole(string role, string nama, int id)
        {

            var serializedModel = new SerializedModel
            {
                Role = role,
                Nama = nama,
                ID = id
            };

            var serializedData = JsonConvert.SerializeObject(serializedModel);
            HttpContext.Session.SetString("Identity", serializedData);
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
