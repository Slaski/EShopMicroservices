namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, string[] Categories, string Description, string ImageFile, decimal Price);
