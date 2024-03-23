


using Authentication.Core.DTOs;
using Authentication.Core.Entity;
using Authentication.DataService.IConfiguration;
using ERP.Authentication.Core.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace Authentication.jwt
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        string key = new ConfigurationBuilder().AddJsonFile("E:/ERP_Admin_portal/ERP_Admin_portal/ERP.Admin/Authentication.jwt/config.json").Build().GetSection("jwt")["secret"];


        private const int JWT_VALIDITY_MINS = 1;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtTokenHandler(IUnitOfWorks unitOfWorks, TokenValidationParameters tokenValidationParameters)
        {
            _unitOfWorks = unitOfWorks;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public  async Task<AuthenticationResponseDTO ?>  GenerateJwtToken(TokenRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) )
            {
                return null;
            }

            /*var userAccount = _userAccounts.Where(x => x.UserName.Equals(request.UserName) && x.Password.Equals(request.Password))
                .FirstOrDefault();

            if (userAccount == null)
                return null;*/

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(key);
      

            var claimsIdentity = new ClaimsIdentity(
                new List<Claim>
                {
                  new Claim("Id", request.UserId),
                  new Claim(JwtRegisteredClaimNames.Name, request.UserName),
                  new Claim(ClaimTypes.Role, request.Role),
                  new Claim(JwtRegisteredClaimNames.Sub ,request.UserName),
                  new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString()),
                });


            var signinCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                );

            var securityTokenDescripter = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signinCredentials
            };

            //create jwt token
            var jwtSecuritTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecuritTokenHandler.CreateToken(securityTokenDescripter);
            var token = jwtSecuritTokenHandler.WriteToken(securityToken);


            //create refresh token
            var refreshtoken = new RefreshToken
            {
                Token = $"{RandomStringGenarator(25)}_{Guid.NewGuid()}" ,
                UserId = request.UserId,
                IsRevoked = false,
                IsUsed = false,
                Status=1,
                JwtId= securityToken.Id,
                ExpiredDate= DateTime.UtcNow.AddMonths(1),
            };
            await _unitOfWorks.RefreshToknes.Add(refreshtoken);
            await _unitOfWorks.CompleteAsync();


            return new AuthenticationResponseDTO
            {
                UserName = request.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
                RefreshToken =refreshtoken.Token,
            };

        }

        private string  RandomStringGenarator(int length)
        {
            var random =new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
