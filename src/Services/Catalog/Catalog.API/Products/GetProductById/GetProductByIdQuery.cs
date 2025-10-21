namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
