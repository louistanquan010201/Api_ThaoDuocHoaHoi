using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;
using ShowChoThanh.Repomstory.Inplyment;
using ShowChoThanh.Repomstory.Interface;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {

        public static string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return "MHH" + randomNumber.ToString();
        }
        private readonly IDanhMuc _danhMucRepon;

        public DanhMucController(IDanhMuc danhMucRepon)
        {
            _danhMucRepon = danhMucRepon;
        }
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            var db = await _danhMucRepon.GetAllAsync();
            return Ok(db);
        }

        [HttpPost]
        public async Task<IActionResult>  AddDanhMuc([FromBody] DanhMuc request)
        {
            if (ModelState.IsValid)
            {
                request.MaDanhMuc = GenerateRandomNumber();
                request.TinhTrang = "Còn";
               await _danhMucRepon.CreateAsync(request);
                
                return Ok(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{MaDanhMuc}")]
        public async Task<IActionResult>  UpdateMay(string MaDanhMuc, [FromBody] SuaDanhMucDto request)
        {
            if (ModelState.IsValid)
            {
                var test = await _danhMucRepon.GetDanhMucById(MaDanhMuc);
                if (test == null)
                {
                    return NotFound();
                }
                var danhMuc = new DanhMuc
                {
                    MaDanhMuc = MaDanhMuc,
                    TenDanhMuc = request.TenDanhMuc,
                    MoTa = request.MoTa,
                    TinhTrang= request.TinhTrang,
                };


                await _danhMucRepon.UpdateAsync(danhMuc);
                return Ok(danhMuc);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("Delete/{MaDanhMuc}")]
        public async Task<IActionResult>  DeletMay(string MaDanhMuc)
        {
            if (ModelState.IsValid)
            {
                var test = await _danhMucRepon.DeleteAsync(MaDanhMuc);
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
        //[HttpGet("GetName/{TenDanhMuc}")]
        ////public Task<> IActionResult TimTenMay(string TenDanhMuc)
        ////{
        ////    var test = _db.DanhMucs.Where(x => x.TenDanhMuc == TenDanhMuc).ToList();
        ////    return Ok(test);
        ////}
        [HttpGet("GetId/{MaDanhMuc}")]
        public async Task<IActionResult>  TimMaMay(string MaDanhMuc)
        {
             var test = await _danhMucRepon.GetDanhMucById(MaDanhMuc);
            return Ok(test);
        }
        
    }
}
