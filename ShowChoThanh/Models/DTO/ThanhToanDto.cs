using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.DTO
{
    public class ThanhToanDto
    {
        public string MaKhachHang { get; set; }

        public decimal TongTien { get; set; }

        public DateTime NgayThanhToan { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}
