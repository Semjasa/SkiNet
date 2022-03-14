namespace SkiNet.Api.Controllers;

public class BasketController : BaseApiController
{
    private readonly IMapper _mapper;

    public BasketController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById([FromServices] IBasketRepository basketRepository, string id)
    {
        var basket = await basketRepository.GetBasketAsync(id);

        return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync([FromServices] IBasketRepository basketRepository, CustomerBasketDto basketDto)
    {
        var basket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basketDto);

        var updatedBasket = await basketRepository.CreateOrUpdateBasketAsync(basket);

        return Ok(updatedBasket);
    }

    [HttpDelete]
    public async Task DeleteBasketAsync([FromServices] IBasketRepository basketRepository, string id)
    {
        await basketRepository.DeleteBasketAsync(id);
    }
}
