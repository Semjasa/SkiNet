namespace SkiNet.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductBrandRepository, ProductBrandRepository>()
            .AddScoped<IProductTypeRepository, ProductTypesRepository>();
}
