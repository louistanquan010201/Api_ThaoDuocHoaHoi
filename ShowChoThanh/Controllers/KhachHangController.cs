using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return "KH" + randomNumber.ToString();
        }
        ThaoDuocHoaHoiDbContext _db;
        public KhachHangController(ThaoDuocHoaHoiDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var db = _db.khachHangs.ToList();
            return Ok(db);
        }
        [HttpPost]
        public IActionResult AddKhachHang([FromBody] KhachHang request)
        {
            if (ModelState.IsValid)
            {
                request.MaKhachHang = GenerateRandomNumber();
                request.TinhTrang = "Đang Hoạt Động";
                _db.khachHangs.Add(request);
                _db.SaveChanges();
                return Ok(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{MaKhachHang}")]
        public IActionResult UpdateKH(string MaKhachHang, [FromBody] KhachHangDto request)
        {
            if (ModelState.IsValid)
            {
                var test = _db.khachHangs.Find(MaKhachHang);
                if (test == null)
                {
                    return NotFound();
                }
                test.TenKhachHang = request.TenKhachHang;
                test.NgaySinh = request.NgaySinh;   
                test.TinhTrang = request.TinhTrang;
                test.SoDienThoai = request.SoDienThoai;
                test.Email = request.Email;
                test.NgayTao = request.NgayTao;
                test.SoDu = request.SoDu;
                test.TinhTrang = request.TinhTrang;
                test.GhiChu = request.GhiChu;
                _db.SaveChanges();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("Delete/{MaKhachHang}")]
        public IActionResult DeletKH(string MaKhachHang, [FromBody] KhachHangDto KhachHang)
        {
            if (ModelState.IsValid)
            {
                var test = _db.khachHangs.Find(MaKhachHang);
                if (test == null)
                {
                    return NotFound();
                }
                test.TinhTrang = "Ngừng Hoạt Động";
                _db.SaveChanges();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("GetName/{TenKhachHang}")]
        public IActionResult TimTenKH(string TenKhachHang)
        {
            var test = _db.khachHangs.Where(x => x.TenKhachHang == TenKhachHang).ToList();
            return Ok(test);
        }
        [HttpGet("GetId/{MaKhachHang}")]
        public IActionResult TimMaKH(string MaKhachHang)
        {
            var test = _db.khachHangs.FirstOrDefault(x => x.MaKhachHang == MaKhachHang);
            return Ok(test);
        }
        [HttpDelete]
        public IActionResult XoaKH(string MaKhachHang)
        {
            if (!ModelState.IsValid)
            {
                var test = _db.khachHangs.FirstOrDefault(z => z.MaKhachHang == MaKhachHang);
                _db.khachHangs.Remove(test);
                _db.SaveChanges();

            }
            return Ok(ModelState);

        }
    }
}
