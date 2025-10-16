namespace BuildingBlocks.CQRS;

public interface ICommand : ICommand<Unit> { }

public interface ICommand<out TResponse>
    where TResponse : notnull { }
