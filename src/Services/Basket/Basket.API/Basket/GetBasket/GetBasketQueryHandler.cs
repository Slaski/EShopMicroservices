namespace Basket.API.Basket.GetBasket;

public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> HandleAsync(GetBasketQuery query, CancellationToken cancellationToken = default)
    {
        //TODO: get basket from database
        //var basket = await _repository.GetBasket(query.UserName);

        return new GetBasketResult(new ShoppingCart(query.UserName));
    }
}
