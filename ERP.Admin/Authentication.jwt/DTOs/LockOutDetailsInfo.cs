using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.jwt.DTOs
{
    public class LockOutDetailsInfo
    {
        [Required]
        public string  Email { get; set; }
        public bool  LockoutEnable { get; set; }

        public DateTimeOffset LockoutEndDate   { get; set; } 


    }
}
