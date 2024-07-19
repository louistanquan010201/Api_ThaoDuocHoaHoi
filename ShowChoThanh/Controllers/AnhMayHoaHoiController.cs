using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnhMayHoaHoiController : ControllerBase
    {
        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return "KH" + randomNumber.ToString();
        }
        ThaoDuocHoaHoiDbContext _db;
        public AnhMayHoaHoiController(ThaoDuocHoaHoiDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult GetMayHoaHoi()
        {
            var db = _db.AnhMayHoaHois.ToList();
            return Ok(db);
        }
        [HttpPost]
        public async Task<IActionResult> AddImg(IFormFile imgFile, [FromForm] AnhMayHoaHoiDto img)
        {
            if (imgFile == null || imgFile.Length == 0)
            {
                ModelState.AddModelError("imgFile", "Ảnh không hợp lệ.");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {

                var imgDirectory = @"F:\OneDrive\Desktop\ShowChoThanh\ShowChoThanh\img";

                if (!Directory.Exists(imgDirectory))
                {
                    Directory.CreateDirectory(imgDirectory);
                }

                var fileName = Path.GetRandomFileName() + Path.GetExtension(imgFile.FileName);
                var filePath = Path.Combine(imgDirectory, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imgFile.CopyToAsync(stream);
                }
                var imgHoaHoi = new AnhMayHoaHoi
                {
                    MaAnh = GenerateRandomNumber(),
                    LinkAnh = fileName,
                    MaMay = img.MaMay,
                };

                _db.AnhMayHoaHois.Add(imgHoaHoi);
                _db.SaveChanges();

                return Ok(img);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
