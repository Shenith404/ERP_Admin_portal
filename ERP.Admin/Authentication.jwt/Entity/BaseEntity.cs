

using Microsoft.AspNetCore.Identity;

namespace ERP.Authentication.Jwt.Entity;

public class BaseEntity :IdentityUser<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public int Status { get; set; }

}
