
using System.ComponentModel.DataAnnotations;

namespace ERP.Authentication.Jwt.DTOs
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string JwtToken { get; set; } 
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public bool ? IsLocked { get; set; } 
        public bool ? EmailConfirmed { get; set; }
        public  string Message { get; set; }



    }
}
