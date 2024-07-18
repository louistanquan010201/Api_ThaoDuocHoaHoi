using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ShowChoThanh.Models.Domain;

namespace APIHocTapTrucTuyen.Models.Domain
{
    public class ChiTietThanhToan
    {
        [Key]
        public string MaChiTietThanhToan { get; set; }

       
        public string MaMay { get; set; }

        public string MaThanhToan { get; set; }

        public decimal Gia { get; set; }


        [ForeignKey("MaThanhToan")]
        public ThanhToan ThanhToan { get; set; }
        [ForeignKey("MaMay")]
        public MayHoaHoi mayHoaHoi { get; set; }
    }
}
