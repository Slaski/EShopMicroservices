namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand { }

public interface ICommandHandler<in TCommand, TResponse> 
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
