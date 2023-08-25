using System.Linq;
using System.Security.Claims;

namespace EShop.API.Extentions
{
    public static class ClaimsPrincepleExtention
    {

        public static string CurrentUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email).Value;
        }
    }
}
