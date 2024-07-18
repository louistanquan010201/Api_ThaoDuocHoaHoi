namespace ShowChoThanh.Models.DTO
{
    public class LoginReponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public KhachHangDto KhachHang { get; set; }
       
    }
}
