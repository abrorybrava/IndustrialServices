using Microsoft.AspNetCore.Mvc;

namespace IndustrialServices.Controllers
{
    public class DPPController : Controller
    {
        private readonly IWebHostEnvironment _webhost;
        public DPPController(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(List<IFormFile> foto)
        {
            try
            {
                // Check if the list of files is empty
                if (foto == null || foto.Count == 0)
                {
                    return BadRequest("No files were uploaded");
                }

                foreach (var fotofoto in foto)
                {
                    var imgext = Path.GetExtension(fotofoto.FileName);
                    var saveimg = Path.Combine(_webhost.WebRootPath, "assets", "img", fotofoto.FileName);

                    // Validasi format file
                    if (imgext != ".jpg" && imgext != ".png" && imgext != ".jpeg")
                    {
                        return BadRequest("Invalid photo format. Please upload files with .jpg, .png, or .jpeg formats");
                    }

                    // Check if the file with the same name exists in the directory
                    if (System.IO.File.Exists(saveimg))
                    {
                        return BadRequest($"A file with the same name already exists in the directory: {fotofoto.FileName}");
                    }

                    // Simpan file
                    using (var uploading = new FileStream(saveimg, FileMode.Create))
                    {
                        await fotofoto.CopyToAsync(uploading);
                    }
                }

                return Ok("Data berhasil diupload ke wwwroot");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan: {ex.Message}");
            }
        }

    }
}
