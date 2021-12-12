namespace SkiNet.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSkiNetContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<DataContext>(options => 
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
}
