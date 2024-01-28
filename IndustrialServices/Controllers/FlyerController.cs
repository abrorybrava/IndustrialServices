using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class FlyerController : Controller
    {
        private readonly IWebHostEnvironment _webhost;

        public FlyerController(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFlyer(IFormFile flyer)
        {
            try
            {
                if (flyer == null || flyer.Length == 0)
                {
                    return BadRequest("File kosong");
                }

                var imgext = Path.GetExtension(flyer.FileName);
                var saveimgDirectory = Path.Combine(_webhost.WebRootPath, "assets", "img");

                // Pastikan folder "assets/img" sudah ada, jika belum, buat folder tersebut
                if (!Directory.Exists(saveimgDirectory))
                {
                    Directory.CreateDirectory(saveimgDirectory);
                }

                var saveimg = Path.Combine(saveimgDirectory, flyer.FileName);

                // ... (kode sebelumnya)

                using (var uploading = new FileStream(saveimg, FileMode.Create))
                {
                    await flyer.CopyToAsync(uploading);
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
