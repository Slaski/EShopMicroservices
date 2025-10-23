using BuildingBlocks.CQRS;
using FluentValidation;

namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TCommand, TResult>(IEnumerable<IValidator<TCommand>> validators)
    : IPipelineBehavior<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    public async Task<TResult> HandleAsync(TCommand command, Func<Task<TResult>> next, CancellationToken cancellationToken = default)
    {
        var context = new ValidationContext<TCommand>(command);
        var validationResults =
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToArray();

        if (failures.Any())
            throw new ValidationException(failures);

        return await next();
    }
}
