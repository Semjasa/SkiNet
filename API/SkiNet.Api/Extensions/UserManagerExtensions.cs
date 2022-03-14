using Microsoft.EntityFrameworkCore;

namespace SkiNet.Api.Extensions;

public static class UserManagerExtensions
{
    public static async Task<AppUser> FindByClaimsPrincipalWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal claimsPrincipal)
    {
        var email = claimsPrincipal?.FindFirstValue(ClaimTypes.Email);

        return await input?.Users?.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
    }

    public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> input, ClaimsPrincipal claimsPrincipal)
    {
        var email = claimsPrincipal?.FindFirstValue(ClaimTypes.Email);

        return await input?.Users?.SingleOrDefaultAsync(x => x.Email == email);
    }
}
