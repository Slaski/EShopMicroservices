namespace BuildingBlocks.CQRS;

public interface IQuery<out TResponse>
    where TResponse : notnull { }
