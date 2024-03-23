using Authentication.jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ERP.Authentication.Jwt
{
    public static class CustomJwtAuthExtension
    {
        public static void AddCustomJwtAuthenticaion(this IServiceCollection services)
        {

            string key = new ConfigurationBuilder().AddJsonFile("D:/Projects/ERP_Admin/ERP_Admin_portal/ERP.Admin/Authentication.jwt/config.json").Build().GetSection("jwt")["secret"];

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))

                };
            });
        } 
    }
}
