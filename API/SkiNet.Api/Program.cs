var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddSkiNetContext(configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var loggerFactory = services
        .GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services
            .GetRequiredService<DataContext>();

        await context.Database
            .MigrateAsync();

        await DataContextSeed
            .SeedAsync(context, loggerFactory);
    }
    catch (Exception ex) {
        var logger = loggerFactory
            .CreateLogger<Program>();

        logger
            .LogError(ex, "An error occured during migration.");
    }
}

app.UseApplicationDefaults();

app.UseStaticFiles();

app.MapControllers();

app.Run();
