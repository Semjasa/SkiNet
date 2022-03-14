namespace SkiNet.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationDefaults(this IApplicationBuilder applicationBuilder) => 
        applicationBuilder
            .UseMiddleware<ExceptionMiddleware>()
            .UseSwagger()
            .UseSwaggerUI()
            .UseStatusCodePagesWithReExecute("/errors/{0}")
            .UseHttpsRedirection()
            .UseCors("CorsPolicy")
            .UseAuthentication()
            .UseAuthorization();
}
