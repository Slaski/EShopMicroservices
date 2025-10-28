namespace Catalog.API.Products.GetProductByCategory;

public class GetProductByCategoryQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> HandleAsync(GetProductByCategoryQuery query, CancellationToken cancellationToken = default)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}
