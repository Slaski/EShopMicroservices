namespace Catalog.API.Products.GetProducts;

public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("GetproductsQueryHandler.Handle called with {@Quert}", query);

        var products = await session.Query<Product>().ToListAsync();
        return new GetProductsResult(products);
    }
}
