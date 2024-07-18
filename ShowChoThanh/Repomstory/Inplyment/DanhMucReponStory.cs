using Microsoft.EntityFrameworkCore;
using ShowChoThanh.Models.Domain;
using ShowChoThanh.MyDb;
using ShowChoThanh.Repomstory.Interface;

namespace ShowChoThanh.Repomstory.Inplyment
{
    public class DanhMucReponStory : IDanhMuc
    {
        private readonly ThaoDuocHoaHoiDbContext _db;
        public DanhMucReponStory(ThaoDuocHoaHoiDbContext db)
        {
            _db = db;   
        }
        public async Task<DanhMuc> CreateAsync(DanhMuc danhMuc)
        {
           await _db.DanhMucs.AddAsync(danhMuc);
           await _db.SaveChangesAsync();
            return danhMuc;
        }

        public async Task<DanhMuc?> DeleteAsync(string id)
        {
            var existingDanhMuc = await _db.DanhMucs.FindAsync(id);
            existingDanhMuc.TinhTrang = "Khoong con";
            if (existingDanhMuc != null)
            {
                _db.DanhMucs.Update(existingDanhMuc);
                await _db.SaveChangesAsync();
                return existingDanhMuc;
            }
            return null;
        }

        public async Task<IEnumerable<DanhMuc>> GetAllAsync()
        {
            return await _db.DanhMucs.ToListAsync();

        }

        public async Task<DanhMuc?> GetDanhMucById(string id)
        {
            return await _db.DanhMucs.FirstOrDefaultAsync(x => x.MaDanhMuc == id);
        }

        public async Task<DanhMuc?> UpdateAsync(DanhMuc danhMuc)
        {
            var existingDanhMuc = await _db.DanhMucs.FirstOrDefaultAsync(x => x.MaDanhMuc == danhMuc.MaDanhMuc);
            if (existingDanhMuc == null)
            {
                return null;
            }
            _db.Entry(existingDanhMuc).CurrentValues.SetValues(danhMuc);
            await _db.SaveChangesAsync();
            return danhMuc;
        }
    }
}
