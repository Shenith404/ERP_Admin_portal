﻿using Authentication.jwt.DTOs;
using ERP.Authentication.Jwt.DTOs;
using ERP.Authentication.Jwt.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.jwt
{
    public class JwtTokenHandler
    {
        string key = new ConfigurationBuilder().AddJsonFile("E:/ERP_Admin_portal/ERP_Admin_portal/ERP.Admin/Authentication.jwt/config.json").Build().GetSection("jwt")["secret"];


        private const int JWT_VALIDITY_MINS = 1;

        public JwtTokenHandler()
        {
           
        }

        public  AuthenticationResponse? GenerateJwtToken(TokenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
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


            var jwtSecuritTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecuritTokenHandler.CreateToken(securityTokenDescripter);
            var token = jwtSecuritTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = request.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };

        }
    }
}
