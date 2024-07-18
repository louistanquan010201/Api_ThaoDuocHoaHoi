using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowChoThanh.Repomstory.Interface;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController(IDanhMuc _danhMucRepon) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var db = await _danhMucRepon.GetAllAsync();
            return Ok(db);
        }
    }
}
