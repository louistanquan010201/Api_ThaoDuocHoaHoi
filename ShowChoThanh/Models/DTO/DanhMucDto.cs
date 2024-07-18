using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.DTO
{
    public class DanhMucDto
    {
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string AnhDanhMuc { get; set; }

        public string MoTa { get; set; }
        public string TinhTrang { get; set; }
    }
}
