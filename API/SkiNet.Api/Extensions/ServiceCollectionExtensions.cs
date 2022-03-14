namespace SkiNet.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSkiNetContext(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddApplicationCors()
            .AddEndpointsApiExplorer()
            .AddAutoMapper(typeof(MappingProfiles))
            .AddDataContextConfiguration(configuration)
            .AddRedis(configuration)
            .AddSwaggerDocumentation()
            .AddApiBehaviorConfiguration()
            .AddRepositories(configuration);

    private static IServiceCollection AddApiBehaviorConfiguration(this IServiceCollection services) =>
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(kvp => kvp.Value?.Errors.Count > 0)
                    .SelectMany(selector: kvp => kvp.Value.Errors)
                    .Select(modelError => modelError.ErrorMessage)
                    .ToArray();

                var errorResponse = new ApiValidationErrorResponse { Errors = errors };

                return new BadRequestObjectResult(errorResponse);
            };
        });

    private static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) =>
        services
            .AddSwaggerGen(options =>
            {
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Schema",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirements = new OpenApiSecurityRequirement
                {
                    { securitySchema, new [] { "Bearer" } }
                };

                options.AddSecurityRequirement(securityRequirements);
            });

    private static IServiceCollection AddDataContextConfiguration(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDbContext<DataContext>(options =>
                options
                    .UseSqlite(configuration.GetConnectionString("DefaultConnection")));

    private static IServiceCollection AddApplicationCors(this IServiceCollection services) =>
        services
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });

    private static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddSingleton<IConnectionMultiplexer>(c =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });
}
