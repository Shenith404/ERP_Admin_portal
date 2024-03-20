﻿

using System.ComponentModel.DataAnnotations;

namespace ERP.Authentication.Jwt.DTOs
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
