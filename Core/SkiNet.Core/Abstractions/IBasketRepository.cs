namespace SkiNet.Core.Abstractions;

public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string basketId);
    Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string basketId);
}
 