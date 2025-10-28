﻿namespace Catalog.API.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> HandleAsync(GetProductByIdQuery query, CancellationToken cancellationToken = default)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(query.Id);

        return new GetProductByIdResult(product);
    }
}
