using BuildingBlocks.CQRS;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TInput, TOutput>
        (ILogger<LoggingBehavior<TInput, TOutput>> logger)
        : IPipelineBehavior<TInput, TOutput>
        where TInput : notnull
        where TOutput : notnull
    {
        public async Task<TOutput> HandleAsync(TInput input, Func<Task<TOutput>> next, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
                typeof(TInput).Name, typeof(TOutput).Name, input);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            var timeTaken = timer.Elapsed;
            if (timeTaken.Seconds > 3)
                logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken}",
                    typeof(TInput).Name, timeTaken);

            logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TInput).Name, response);
            
            return response;
        }
    }
}
