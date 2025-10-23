
namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", command);

        session.Delete(command.Id);
        await session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
