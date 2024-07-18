using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhToanController : ControllerBase
    {
        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return "MTH" + randomNumber.ToString();
        }
        ThaoDuocHoaHoiDbContext _db;
        public ThanhToanController(ThaoDuocHoaHoiDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var db = _db.ThanhToans.ToList();
            return Ok(db);
        }
        [HttpPost]
        public IActionResult AddThanhToan([FromBody] ThanhToanDto request)
        {
            if (ModelState.IsValid)
            {
                var khachHang = _db.khachHangs.FirstOrDefault(x => x.MaKhachHang == request.MaKhachHang);
                var thanhToan = new ThanhToan
                {
                    MaThanhToan = GenerateRandomNumber(),
                    MaKhachHang = request.MaKhachHang,
                    TongTien = request.TongTien,
                    NgayThanhToan = request.NgayThanhToan,
                    TinhTrang = request.TinhTrang,
                    GhiChu = request.GhiChu,
                    KhachHang = khachHang
                };
                _db.ThanhToans.Add(thanhToan);
                _db.SaveChanges();
                return Ok(thanhToan);


            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{MaThanhToan}")]
        public IActionResult UpdateThanhToan(string MaThanhToan, [FromBody] ThanhToanDto request)
        {
            if (ModelState.IsValid)
            {
                var test = _db.ThanhToans.Find(MaThanhToan);
                if (test == null)
                {
                    return NotFound();
                }
                test.MaKhachHang = request.MaKhachHang;
                test.NgayThanhToan = request.NgayThanhToan;
                test.TinhTrang = request.TinhTrang;
                test.TongTien = request.TongTien;
                test.GhiChu = request.GhiChu;
                _db.SaveChanges();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("Delete/{MaThanhToan}")]
        public IActionResult DeletMaThanhToan(string MaThanhToan, [FromBody] ThanhToanDto thanhToan)
        {
            if (ModelState.IsValid)
            {
                var test = _db.ThanhToans.Find(MaThanhToan);
                if (test == null)
                {
                    return NotFound();
                }
                test.TinhTrang = "Chưa ThanhToan";
                _db.SaveChanges();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("GetId/{MaThanhToan}")]
        public IActionResult TimMaThanhToan(string MaThanhToan)
        {
            var test = _db.ThanhToans.FirstOrDefault(x => x.MaThanhToan == MaThanhToan);
            return Ok(test);
        }
        [HttpDelete]
        public IActionResult XoaMay(string MaDanhMuc)
        {
            if (!ModelState.IsValid)
            {
                var test = _db.DanhMucs.FirstOrDefault(z => z.MaDanhMuc == MaDanhMuc);
                _db.DanhMucs.Remove(test);
                _db.SaveChanges();

            }
            return Ok(ModelState);

        }
    }
}
