using ShowChoThanh.Models.Domain;

namespace ShowChoThanh.Repomstory.Interface
{
    public interface ISanPham
    {
        Task<MayHoaHoi> CreateAsync(MayHoaHoi mayHoaHoi);
        Task<IEnumerable<MayHoaHoi>> GetAllAsync();
        Task<MayHoaHoi?> UpdateAsync(MayHoaHoi mayHoaHoi);
        Task<MayHoaHoi?> DeleteAsync(string id);
        Task<MayHoaHoi?> GetMayHoaHoiById(string id);
        
    }
}
