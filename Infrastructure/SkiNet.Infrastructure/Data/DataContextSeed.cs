namespace SkiNet.Infrastructure.Data;

public class DataContextSeed
{
    public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.ProductBrands.Any())
            {
                var brandDatas = File
                    .ReadAllText("../../Infrastructure/SkiNet.Infrastructure/Data/SeedData/brands.json");

                var brands = JsonSerializer
                    .Deserialize<List<ProductBrand>>(brandDatas);

                await context.ProductBrands
                    .AddRangeAsync(brands);

                await context
                    .SaveChangesAsync();
            }

            if (!context.ProductTypes.Any())
            {
                var typeDatas = File
                    .ReadAllText("../../Infrastructure/SkiNet.Infrastructure/Data/SeedData/types.json");

                var types = JsonSerializer
                    .Deserialize<List<ProductType>>(typeDatas);

                await context.ProductTypes
                    .AddRangeAsync(types);

                await context
                    .SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productDatas = File
                    .ReadAllText("../../Infrastructure/SkiNet.Infrastructure/Data/SeedData/products.json");

                var products = JsonSerializer
                    .Deserialize<List<Product>>(productDatas);

                await context.Products
                    .AddRangeAsync(products);

                await context
                    .SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory
                .CreateLogger<DataContextSeed>();

            logger
                .LogError(ex.Message);
        }
    }
}
