using APIHocTapTrucTuyen.Models.Domain;
using Microsoft.EntityFrameworkCore;
using ShowChoThanh.Models.Domain;

namespace ShowChoThanh.MyDb
{
    public class ThaoDuocHoaHoiDbContext : DbContext
    {
        public ThaoDuocHoaHoiDbContext(DbContextOptions<ThaoDuocHoaHoiDbContext> options) : base(options)
        {
        }

        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<MayHoaHoi>MayHoaHois { get; set; }
        public DbSet<AnhMayHoaHoi> AnhMayHoaHois { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<ChiTietThanhToan> ChiTietThanhToans { get; set; }
    }
}
