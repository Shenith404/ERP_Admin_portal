﻿
namespace ERP.Authentication.Jwt.DTOs
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string JwtToken { get; set; }    
        public int ExpiresIn { get; set; }
        public string Message { get; set; } 


    }
}
