using Microsoft.EntityFrameworkCore;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.MyDb;
using ShowChoThanh.Repomstory.Interface;

namespace ShowChoThanh.Repomstory.Inplyment
{
    public class MayHoaHoiReponStory : ISanPham
    {
        private readonly ThaoDuocHoaHoiDbContext _db;
        public MayHoaHoiReponStory(ThaoDuocHoaHoiDbContext db)
        {
            _db = db;
        }
        public async Task<MayHoaHoi> CreateAsync(MayHoaHoi mayHoaHoi)
        {
            await _db.MayHoaHois.AddAsync(mayHoaHoi);
            await _db.SaveChangesAsync();
            return mayHoaHoi;

        }

        public async Task<MayHoaHoi?> DeleteAsync(string id)
        {
            var existingMayHoaHoi = await _db.MayHoaHois.FindAsync(id);
            if (existingMayHoaHoi != null)
            {
                existingMayHoaHoi.TinhTrang = "Khoong con";

                _db.MayHoaHois.Update(existingMayHoaHoi);
                await _db.SaveChangesAsync();
                return existingMayHoaHoi;
            }
            return null;  
        }
        public async Task<IEnumerable<MayHoaHoi>> GetAllAsync()
        {
            return await _db.MayHoaHois.ToListAsync();
            
        }

        public async Task<MayHoaHoi?> GetMayHoaHoiById(string id)
        {
            return await _db.MayHoaHois.FirstOrDefaultAsync(x => x.MaMay == id);
        }

        public async Task<MayHoaHoi?> UpdateAsync(MayHoaHoi mayHoaHoi)
        {
            var existingDanhMuc = await _db.MayHoaHois.FirstOrDefaultAsync(x => x.MaMay == mayHoaHoi.MaMay);
            if (existingDanhMuc == null)
            {
                return null;
            }
            _db.Entry(existingDanhMuc).CurrentValues.SetValues(mayHoaHoi);
            await _db.SaveChangesAsync();
            return mayHoaHoi;
        }
    }
}
