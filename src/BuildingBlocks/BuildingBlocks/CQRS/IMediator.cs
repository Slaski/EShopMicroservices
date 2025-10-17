namespace BuildingBlocks.CQRS
{
    public interface IMediator
    {
        Task<TResult> SendCommandAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>
            where TResult : notnull;

        Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>
            where TResult : notnull;
    }
}
