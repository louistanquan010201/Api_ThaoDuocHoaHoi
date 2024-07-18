namespace ShowChoThanh.Models.DTO
{
    public class SuaKhachHangDto
    {
        public string TenKhachHang { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public DateTime NgaySinh { get; set; }

        public DateTime NgayTao { get; set; }

        public decimal SoDu { get; set; }

        public string TinhTrang { get; set; }
        public string AnhKhachHang { get; set; }

        public string GhiChu
        {
            get; set;
        }
    }
}
