namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductCommandHandler(IDocumentSession session)
{
    public async Task<DeleteProductResult> HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken = default)
    {
        session.Delete(command.Id);
        await session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
