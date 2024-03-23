using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.jwt.DTOs
{
    public class TokenRespnce
    {
        public string  Jwt { get; set; }
        public string RefreshToken { get; set; }
    }
}
