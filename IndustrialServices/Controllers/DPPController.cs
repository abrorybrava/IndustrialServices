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
            foreach (var fotofoto in foto)
            {
                var imgext = Path.GetExtension(fotofoto.FileName);
                var saveimg = Path.Combine(_webhost.WebRootPath, "assets", "img", fotofoto.FileName);

                if (foto == null)
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
                            await fotofoto.CopyToAsync(uploading);
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
            return Ok();
        }
    }
}
