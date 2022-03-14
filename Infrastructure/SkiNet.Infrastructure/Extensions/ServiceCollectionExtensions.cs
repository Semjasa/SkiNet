using SkiNet.Infrastructure.Services;

namespace SkiNet.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddIdentityDbContext(configuration)
            .AddIdentityServices(configuration)
            .AddRepositories()
            .AddServices();

    private static IServiceCollection AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("IdentityConnection"));
            });

    private static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        var builder = services.AddIdentityCore<AppUser>();

        builder = new IdentityBuilder(builder.UserType, builder.Services);
        builder.AddEntityFrameworkStores<AppIdentityDbContext>();
        builder.AddSignInManager<SignInManager<AppUser>>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<ITokenService, TokenService>();

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<IBasketRepository, BasketRepository>();

}
