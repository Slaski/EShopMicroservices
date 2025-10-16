using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> HandleAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Categories = request.Categories,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Price = request.Price
        };

        return new CreateProductResult(product.Id);
    }
}
