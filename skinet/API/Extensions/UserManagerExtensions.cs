using Core.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimPrincipleWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            var email = user?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;

            return await userManager.Users.Include(a => a.Address).SingleOrDefaultAsync(a => a.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipleAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            var email = user?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;

            return await userManager.Users.SingleOrDefaultAsync(a => a.Email == email);
        }
    }
}
