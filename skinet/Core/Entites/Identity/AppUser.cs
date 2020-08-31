using Microsoft.AspNetCore.Identity;

namespace Core.Entites.Identity
{
    //gets from Microsoft.Extensions.Identity.Stores package, instead of deriving from base entity.
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
