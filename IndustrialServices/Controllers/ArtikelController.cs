using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class ArtikelController : Controller
    {
        private readonly IWebHostEnvironment _webhost;
        public ArtikelController(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Draft(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile sampulartikel)
        {
            var imgext = Path.GetExtension(sampulartikel.FileName);
            var saveimg = Path.Combine(_webhost.WebRootPath, "assets", "img", sampulartikel.FileName);

            if (sampulartikel == null)
            {
                return Ok("File kosong");
            }

            if (imgext == ".jpg" || imgext == ".png" || imgext == ".jpeg")
            {
                // Check if the file with the same name exists in the directory
                if (!System.IO.File.Exists(saveimg))
                {
                    using (var uploading = new FileStream(saveimg, FileMode.Create))
                    {
                        await sampulartikel.CopyToAsync(uploading);
                        return Ok("Data berhasil diupload ke wwwroot");
                    }
                }
                else
                {
                    return Ok("File dengan nama yang sama sudah ada di direktori");
                }
            }
            else
            {
                return Ok("Format foto tidak valid. Harap unggah file dengan format .jpg atau .png");
            }
        }
    }
}
