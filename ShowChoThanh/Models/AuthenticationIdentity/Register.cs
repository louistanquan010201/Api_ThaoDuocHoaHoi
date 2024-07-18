using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.AuthenticationIdentity
{
    public class Register
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string TenKhachHang { get; set; }

        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? NgaySinh { get; set; }
        public string AnhKhachHang { get; set; }
    }
}
