using BuildingBlocks.CQRS;

namespace Catalog.API.Configurations
{
    internal static class QueryConfigurations
    {
        public static void AddQueries(this IServiceCollection services)
        {
            var types = typeof(CommandConfigurations).Assembly.GetTypes();
            var queryHandlerTypes = types
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces(), (type, iface) => new { Type = type, Interface = iface })
                .Where(x => x.Interface.IsGenericType && x.Interface.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
                .ToArray();

            foreach (var handler in queryHandlerTypes)
                services.AddTransient(handler.Interface, handler.Type);
        }
    }
}
