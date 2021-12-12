namespace SkiNet.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseDefaultHttpsRedirection(this IApplicationBuilder applicationBuilder) => 
        applicationBuilder.UseHttpsRedirection();

    public static IApplicationBuilder UseDefaultAuthorization(this IApplicationBuilder applicationBuilder) => 
        applicationBuilder.UseAuthorization();
}
