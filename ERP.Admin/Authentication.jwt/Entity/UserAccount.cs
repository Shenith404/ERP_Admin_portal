using Microsoft.AspNetCore.Identity;

namespace ERP.Authentication.Jwt.Entity
{
    public class UserAccount : BaseEntity

    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTimeOffset LockoutTime { get; set; }

        public int LoginAttemptFailed {  get; set; }



    }
}
