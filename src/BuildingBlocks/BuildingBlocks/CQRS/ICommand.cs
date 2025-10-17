namespace BuildingBlocks.CQRS;

public interface ICommand : ICommand<Unit> { }

public interface ICommand<out TResult>
    where TResult : notnull { }
