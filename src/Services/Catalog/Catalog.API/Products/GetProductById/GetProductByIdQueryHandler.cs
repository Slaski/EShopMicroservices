using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> HandleAsync(GetProductByIdQuery query, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("GetproductByIdQueryHandler.Handle called with {@Query}", query);

        var product = await session.LoadAsync<Product>(query.id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException();

        return new GetProductByIdResult(product);
    }
}
