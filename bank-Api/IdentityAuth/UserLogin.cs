using Microsoft.AspNetCore.Identity;

namespace bank_Api.IdentityAuth
{
    public class UserLogin
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
