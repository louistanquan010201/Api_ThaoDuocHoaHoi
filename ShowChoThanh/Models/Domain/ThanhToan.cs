using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.Domain
{
    public class ThanhToan
    {
        [Key]
        public string MaThanhToan { get; set; }

        public string MaKhachHang { get; set; }

        public decimal TongTien { get; set; }

        public DateTime NgayThanhToan { get; set; }
        [StringLength(50)]
        public string TinhTrang { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }

        [ForeignKey("MaKhachHang")]
        public KhachHang KhachHang { get; set; }
    }
}
