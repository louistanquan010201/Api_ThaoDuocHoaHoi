using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShowChoThanh.Models.DTO;
using ShowChoThanh.MyDb;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShowChoThanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ThaoDuocHoaHoiDbContext _db;
        public AuthController(UserManager<IdentityUser> userManager, ThaoDuocHoaHoiDbContext db, IConfiguration configuration)
        {
            this.userManager = userManager;
            _db = db;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var identityUser = await userManager.FindByEmailAsync(request.Email);

            if (identityUser is not null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    var jwtToken = CreateJwtToken(identityUser, roles.ToList());

                    var khachHangs = await _db.khachHangs.ToListAsync();
                    var responseKhachHang = khachHangs.Select(khachHang => new KhachHangDto
                    {
                        TenKhachHang = khachHang.TenKhachHang,
                        SoDienThoai = khachHang.SoDienThoai,
                        Email = khachHang.Email,
                        NgaySinh = khachHang.NgaySinh,
                        SoDu = khachHang.SoDu,
                        AnhKhachHang = khachHang.AnhKhachHang,
                        GhiChu = khachHang.GhiChu,
                        TinhTrang = khachHang.TinhTrang,
                        NgayTao = khachHang.NgayTao
                    }).ToList();

                    var existKhachHang = responseKhachHang.FirstOrDefault(s => s.Email == request.Email);

                    var response = new LoginReponse
                    {
                        KhachHang = existKhachHang,
                        Email = request.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    return Ok(response);
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }

            return ValidationProblem(ModelState);
        }

        private string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
