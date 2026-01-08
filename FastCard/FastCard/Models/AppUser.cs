using Microsoft.AspNetCore.Identity;

namespace FastCard.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
