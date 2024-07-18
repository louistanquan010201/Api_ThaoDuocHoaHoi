using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.Domain
{
    public class AnhMayHoaHoi
    {
        [Key]
        public string MaAnh { get; set; }

      
        public string MaMay { get; set; }
        public string LinkAnh { get; set; }

        [ForeignKey("MaMay")]
        public MayHoaHoi MayHoaHoi { get; set; }
    }
}
