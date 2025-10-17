namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : notnull
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}