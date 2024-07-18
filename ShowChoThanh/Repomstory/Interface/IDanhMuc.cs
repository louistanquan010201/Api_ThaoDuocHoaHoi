using ShowChoThanh.Models.Domain;

namespace ShowChoThanh.Repomstory.Interface
{
    public interface IDanhMuc
    {
        Task<DanhMuc> CreateAsync(DanhMuc danhMuc);
        Task<IEnumerable<DanhMuc>> GetAllAsync();
        Task<DanhMuc?> UpdateAsync(DanhMuc danhMuc);
        Task<DanhMuc?> DeleteAsync(string id);
        Task<DanhMuc?> GetDanhMucById(string id);
    }
}
