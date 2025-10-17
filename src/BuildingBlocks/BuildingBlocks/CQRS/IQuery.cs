namespace BuildingBlocks.CQRS;

public interface IQuery<out TResult>
    where TResult : notnull { }
