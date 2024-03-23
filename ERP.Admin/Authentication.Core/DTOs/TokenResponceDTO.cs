using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.DTOs
{
    public class TokenResponceDTO
    {
        public string  Jwt { get; set; }
        public string RefreshToken { get; set; }
    }
}
