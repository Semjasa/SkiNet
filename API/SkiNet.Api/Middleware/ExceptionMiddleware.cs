namespace SkiNet.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context == null)
        {
            return;
        }

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var errorCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorCode;

            var response = _environment.IsDevelopment() ?
                new ApiException(errorCode, ex.Message, ex.StackTrace.ToString()) :
                new ApiException(errorCode);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}
