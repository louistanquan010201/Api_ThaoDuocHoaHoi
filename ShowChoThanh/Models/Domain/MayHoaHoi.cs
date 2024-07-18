using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.Domain
{
    public class MayHoaHoi
    {
        [Key]
        public string MaMay { get; set; }

        [StringLength(100)]
        public string TenMay { get; set; }

        public decimal Gia { get; set; }

        public string MoTaMay { get; set; }

        public int GiamGia { get; set; }

       
        public string MaDanhMuc { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }
        public DateTime NgayThem { get; set; }

        [ForeignKey("MaDanhMuc")]
        public DanhMuc DanhMuc { get; set; }

    }
}
