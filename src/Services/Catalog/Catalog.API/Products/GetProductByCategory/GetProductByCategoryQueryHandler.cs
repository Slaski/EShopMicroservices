namespace Catalog.API.Products.GetProductByCategory;

public class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> HandleAsync(GetProductByCategoryQuery query, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("GetproductsByCategoryQueryHandler.Handle called with {@Query}", query);

        var products = await session.Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}
