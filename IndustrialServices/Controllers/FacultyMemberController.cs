using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IndustrialServices.Controllers
{
    public class FacultyMemberController : Controller
    {
        private readonly IWebHostEnvironment _webhost;

        public FacultyMemberController(IWebHostEnvironment webhost)
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

        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile fotopengajar)
        {
            try
            {
                if (fotopengajar == null || fotopengajar.Length == 0)
                {
                    return BadRequest("File kosong");
                }

                var imgext = Path.GetExtension(fotopengajar.FileName);
                var saveimgDirectory = Path.Combine(_webhost.WebRootPath, "assets", "img");

                // Pastikan folder "assets/img" sudah ada, jika belum, buat folder tersebut
                if (!Directory.Exists(saveimgDirectory))
                {
                    Directory.CreateDirectory(saveimgDirectory);
                }

                var saveimg = Path.Combine(saveimgDirectory, fotopengajar.FileName);


                using (var uploading = new FileStream(saveimg, FileMode.Create))
                {
                    await fotopengajar.CopyToAsync(uploading);
                    return Ok("Data berhasil diupload ke wwwroot");
                }
            }
            catch (Exception ex)
            {
                // Tangani kesalahan dengan lebih baik dan kirim status kode 500
                return StatusCode(500, $"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}
