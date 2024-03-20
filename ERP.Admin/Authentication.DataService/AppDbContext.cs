using ERP.Authentication.Jwt.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Authentication.DataService
{
    public class AppDbContext :IdentityDbContext<BaseEntity,IdentityRole<Guid>,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
