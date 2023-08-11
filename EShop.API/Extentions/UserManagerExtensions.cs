using EShop.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EShop.API.Extentions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipleWithAddress(this UserManager<AppUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;

            return await userManager.Users.Include(a => a.Address)
                .SingleOrDefaultAsync(a => a.Email == email);
        }
        public static async Task<Address> FindByEmailFromClaim(this UserManager<AppUser> userManager , ClaimsPrincipal claimsPrincipal)
        {
            return (await userManager.Users.SingleOrDefaultAsync(a => a.Email == claimsPrincipal.FindFirstValue(ClaimTypes.Email))).Address;
        }
       
    }
}
