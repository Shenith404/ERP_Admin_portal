﻿

using Microsoft.AspNetCore.Identity;

namespace ERP.Authentication.Jwt.Entity;

public class UserModel :IdentityUser
{
  
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public int Status { get; set; }

}
