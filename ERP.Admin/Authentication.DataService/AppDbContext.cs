using Authentication.jwt.Entity;
using ERP.Authentication.Jwt.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Authentication.DataService
{
    public class AppDbContext :IdentityDbContext<UserModel>
    {

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
