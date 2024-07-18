using APIHocTapTrucTuyen.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietThanhToanController : ControllerBase
    {
        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return "MHH" + randomNumber.ToString();
        }
        ThaoDuocHoaHoiDbContext _db;
        public ChiTietThanhToanController(ThaoDuocHoaHoiDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var db = _db.ChiTietThanhToans.ToList();
            return Ok(db);
        }
        [HttpPost]
        public IActionResult AddMay([FromBody] ChiTietThanhToanDto request)
        {
            if (ModelState.IsValid)
            {
                var mayHoaHoi = _db.MayHoaHois.FirstOrDefault(x => x.MaMay ==  request.MaMay);
                var ThanhToan = _db.ThanhToans.FirstOrDefault(x => x.MaThanhToan == request.MaThanhToan);
                var ChiTietThanhToan = new ChiTietThanhToan
                
                {
                    MaChiTietThanhToan = GenerateRandomNumber(),
                    Gia = request.Gia,
                    MaThanhToan = request.MaThanhToan,
                    MaMay = request.MaMay,
                    ThanhToan = ThanhToan,
                    mayHoaHoi = mayHoaHoi,
                };

                _db.ChiTietThanhToans.Add(ChiTietThanhToan);
                _db.SaveChanges();
                return Ok(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{MaChiTietThanhToan}")]
        public IActionResult UpdateMay(string MaChiTietThanhToan, [FromBody] ChiTietThanhToanDto request)
        {
            if (ModelState.IsValid)
            {
                var test = _db.ChiTietThanhToans.Find(MaChiTietThanhToan);
                if (test == null)
                {
                    return NotFound();
                }
                test.MaThanhToan = request.MaThanhToan;
                test.MaMay = request.MaMay;
                test.Gia = request.Gia;

                _db.SaveChanges();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
       /* [HttpPut("Delete/{MaChiTietThanhToan}")]
        public IActionResult DeletMay(string MaChiTietThanhToan, [FromBody] ChiTietThanhToanDto chiTietThanhToan)
        {
            if (ModelState.IsValid)
            {
                var test = _db.ChiTietThanhToans.Find(MaChiTietThanhToan);
                if (test == null)
                {
                    return NotFound();
                }
                _db.SaveChanges();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }*/
        [HttpGet("GetId/{MaChiTietThanhToan}")]
        public IActionResult TimMaMay(string MaChiTietThanhToan)
        {
            var test = _db.ChiTietThanhToans.FirstOrDefault(x => x.MaChiTietThanhToan == MaChiTietThanhToan);
            return Ok(test);
        }
        [HttpDelete]
        public IActionResult XoaMay(string MaChiTietThanhToan)
        {
            if (!ModelState.IsValid)
            {
                var test = _db.ChiTietThanhToans.FirstOrDefault(z => z.MaChiTietThanhToan == MaChiTietThanhToan);
                _db.ChiTietThanhToans.Remove(test);
                _db.SaveChanges();

            }
            return Ok(ModelState);

        }
    }
}
