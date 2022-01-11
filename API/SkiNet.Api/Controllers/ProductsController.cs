namespace SkiNet.Api.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IMapper _mapper;

    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Pagination<ProductsToReturnDto>>> GetProducts(
        [FromServices] IGenericRepository<Product> repository,
        [FromQuery] ProductSpecifcationParameters productSpecifcationParameters)
    {
        var specification = new ProductsWithBrandsAndTypesSpecification(productSpecifcationParameters);

        var countSpecification = new ProductsWithFiltersForCountSpecification(productSpecifcationParameters);

        var totalItems = await repository.CountAsync(countSpecification);

        var products = await repository
            .ListAsync(specification);

        var productToReturnDtos = products
            .Select(product => GetProductsToReturnDto(product)).ToArray();

        var pagination = new Pagination<ProductsToReturnDto>(productSpecifcationParameters.PageIndex, productSpecifcationParameters.PageSize, totalItems, productToReturnDtos);

        return Ok(pagination);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductsToReturnDto>> GetProduct([FromServices] IGenericRepository<Product> repository, int id)
    {

        var specification = new ProductsWithBrandsAndTypesSpecification(id);

        var product = await repository
            .GetEntityWithSecificationAsync(specification);

        if (product == null) return NotFound(new ApiResponse(404));

        var productToReturnDto = GetProductsToReturnDto(product);

        return Ok(productToReturnDto);
    }

    private ProductsToReturnDto GetProductsToReturnDto(Product product)
    {
        return _mapper
            .Map<Product, ProductsToReturnDto>(product);
    }
}
