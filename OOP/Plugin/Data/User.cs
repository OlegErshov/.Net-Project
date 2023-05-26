using Microsoft.AspNetCore.Identity;


namespace Plugin.Authorization
{
    public class User : IdentityUser<int>
    {

        public string? Password { get; set; }
    }
}
