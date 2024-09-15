using Microsoft.AspNetCore.Identity;

namespace ComGroups.Services.AuthAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
