namespace SkiNet.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
}
