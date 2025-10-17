using BuildingBlocks.CQRS;

namespace Catalog.API.Configurations
{
    internal static class CommandConfigurations
    {
        public static void AddCommands(this IServiceCollection services)
        {
            var types = typeof(CommandConfigurations).Assembly.GetTypes();
            var commandHandlerTypes = types
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces(), (type, iface) => new { Type = type, Interface = iface })
                .Where(x => x.Interface.IsGenericType && x.Interface.GetGenericTypeDefinition() == typeof(ICommandHandler<,>))
                .ToArray();

            foreach (var handler in commandHandlerTypes)
                services.AddTransient(handler.Interface, handler.Type);
        }
    }
}
