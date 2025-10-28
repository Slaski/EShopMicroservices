using BuildingBlocks.Behaviors;

namespace Catalog.API.Configurations
{
    internal static class BehaviorConfigurations
    {
        public static void AddBehaviors(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }
    }
}