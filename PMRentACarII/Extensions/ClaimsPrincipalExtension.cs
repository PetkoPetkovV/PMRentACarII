using System.Security.Claims;

namespace PMRentACarII.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
           return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
