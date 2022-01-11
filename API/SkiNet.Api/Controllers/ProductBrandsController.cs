namespace SkiNet.Api.Controllers;

public class ProductBrandsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands([FromServices] IGenericRepository<ProductBrand> repository)
    {
        var productBrands = await repository
            .GetAllAync();

        return Ok(productBrands);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductBrand>> GetProductBrand([FromServices] IGenericRepository<ProductBrand> repository, int id)
    {
        var specification = new ProductBrandsSpecification(id);

        var productBrand = await repository
            .GetEntityWithSecificationAsync(specification);

        if (productBrand == null) return NotFound(new ApiResponse(404));

        return Ok(productBrand);
    }
}
