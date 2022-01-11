namespace SkiNet.Api.Controllers;

public class ProductTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes([FromServices] IGenericRepository<ProductType> repository)
    {
        var productTypes = await repository
            .GetAllAync();

        return Ok(productTypes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductType>> GetProductType([FromServices] IGenericRepository<ProductType> repository, int id)
    {
        var specification = new ProductTypesSpecification(id);

        var productType = await repository
            .GetEntityWithSecificationAsync(specification);

        if (productType == null) return NotFound(new ApiResponse(404));

        return Ok(productType);
    }
}
