using System.ComponentModel.DataAnnotations;

namespace ShowChoThanh.Models.AuthenticationIdentity
{
    public class Login
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
