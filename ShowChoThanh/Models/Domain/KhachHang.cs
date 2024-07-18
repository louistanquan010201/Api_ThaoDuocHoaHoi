using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowChoThanh.Models.Domain
{
    public class KhachHang
    {
        [Key]
      
        public string MaKhachHang { get; set; }

       
        public string TenKhachHang { get; set; }

        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime NgaySinh { get; set; }

        public DateTime NgayTao { get; set; }

        public decimal SoDu { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }
        public string AnhKhachHang { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
