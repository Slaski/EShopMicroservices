namespace Catalog.API.Products.GetProducts;

public class GetProductsQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
    {
        var products = await session.Query<Product>().ToListAsync();
        return new GetProductsResult(products);
    }
}
