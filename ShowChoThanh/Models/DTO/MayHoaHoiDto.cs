using ShowChoThanh.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.DTO
{
    public class MayHoaHoiDto
    {
       
        public string MaMay { get; set; }

        public string TenMay { get; set; }

        public decimal Gia { get; set; }

        public string MoTaMay { get; set; }

        public int GiamGia { get; set; }
        
        public string MaDanhMuc { get; set; }

     
        public string TinhTrang { get; set; }

        public DateTime NgayThem { get; set; } = DateTime.Now;

    }
}
