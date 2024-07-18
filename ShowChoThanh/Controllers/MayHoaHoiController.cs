using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ShowChoThanh.Models.Domain;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;
using ShowChoThanh.Repomstory.Interface;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayHoaHoiController : ControllerBase
    {
        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return "MHH" + randomNumber.ToString();
        }
        private readonly ISanPham _MayHoaHoiRepon;
        private readonly IDanhMuc _danhMucRepon;
       
        public MayHoaHoiController(ISanPham MayHoaHoiRepon, IDanhMuc danhMucRepon)
        {
            _MayHoaHoiRepon = MayHoaHoiRepon;
            _danhMucRepon = danhMucRepon;
        }
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            var db = await _MayHoaHoiRepon.GetAllAsync();
            return Ok(db);
        }
        [HttpPost]
        public async Task<IActionResult>  AddMay([FromBody] MayHoaHoiDto request)
        {
            if (ModelState.IsValid)
            {
                var danhMuc = await _danhMucRepon.GetDanhMucById(request.MaDanhMuc);
                var mayHoaHoi = new MayHoaHoi
                {
                    MaMay = GenerateRandomNumber(),
                    TenMay = request.TenMay,
                    Gia = request.Gia,
                    MoTaMay = request.MoTaMay,
                    GiamGia = request.GiamGia,
                    MaDanhMuc = request.MaDanhMuc,
                    TinhTrang = "Đang còn hàng",
                    NgayThem = DateTime.Now,
                    DanhMuc = danhMuc
                   
                };

                await _MayHoaHoiRepon.CreateAsync(mayHoaHoi);
                return Ok(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{MaMay}")]
        public async Task<IActionResult>  UpdateMay(string MaMay, [FromBody] SuaMayHoaHoi request)
        {
           
            if (ModelState.IsValid)
            {

                var test = await _MayHoaHoiRepon.GetMayHoaHoiById(MaMay);
                if (test == null)
                {
                    return NotFound();
                }
                var MayHoaHoi = new MayHoaHoi
                {
                    MaMay = MaMay,
                    TenMay = request.TenMay,
                    MoTaMay = request.MoTaMay,
                    MaDanhMuc = request.MaDanhMuc,
                    Gia = request.Gia,
                    GiamGia = request.GiamGia,
                    TinhTrang = request.TinhTrang,
                    NgayThem = request.NgayThem,
                };
                await _MayHoaHoiRepon.UpdateAsync(MayHoaHoi);
                return Ok(MayHoaHoi);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
       
        //[HttpGet("GetName/{TenMay}")]
        //public IActionResult TimTenMay(string TenMay) 
        //{
        //    var test = _MayHoaHoiRepon.MayHoaHois.Where(x => x .TenMay == TenMay).ToList();
        //    return Ok(test);
        //}
        [HttpGet("GetId/{MaMay}")]
        public IActionResult TimMaMay(string MaMay) 
        {
            var test = _MayHoaHoiRepon.GetMayHoaHoiById(MaMay);
            return Ok(test);
        }
        [HttpDelete("{MaMay}")]
        public async Task<IActionResult>  XoaMay(string MaMay)
        {
            if (ModelState.IsValid)
            {
                var test = await _MayHoaHoiRepon.DeleteAsync(MaMay);
                if (test == null)
                {
                    return NotFound();
                }
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
