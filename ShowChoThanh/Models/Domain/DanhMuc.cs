using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.Domain
{
    public class DanhMuc
    {
        [Key]
       
        public string MaDanhMuc { get; set; }
        [StringLength(50)]
        public string TenDanhMuc { get; set; }

        public string MoTa { get; set; }
        [StringLength(50)]
        public string TinhTrang { get; set; }
    }
}
