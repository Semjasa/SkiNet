namespace SkiNet.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSkiNetContext(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddRepositories()
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            })
            .AddEndpointsApiExplorer()
            .AddAutoMapper(typeof(MappingProfiles))
            .AddDataContextConfiguration(configuration)
            .AddSwaggerDocumentation()
            .AddApiBehaviorConfiguration()
            .AddSwaggerDocumentation();

    private static IServiceCollection AddApiBehaviorConfiguration(this IServiceCollection services) =>
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(kvp => kvp.Value?.Errors.Count > 0)
                    .SelectMany(kvp => kvp.Value.Errors)
                    .Select(modelError => modelError.ErrorMessage)
                    .ToArray();

                var errorResponse = new ApiValidationErrorResponse { Errors = errors };

                return new BadRequestObjectResult(errorResponse);
            };
        });

    private static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) =>
        services
            .AddSwaggerGen();

    private static IServiceCollection AddDataContextConfiguration(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDbContext<DataContext>(options =>
                options
                    .UseSqlite(configuration.GetConnectionString("DefaultConnection")));


}
