namespace SkiNet.Core.Abstractions;

public interface ITokenService
{
    string CreateToken(AppUser appUser);
}
