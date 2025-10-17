using BuildingBlocks.CQRS;

namespace Catalog.API.Configurations
{
    internal static class MediatorConfigurations
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddSingleton<IMediator, Mediator>();
            services.AddCommands();
            services.AddQueries();
        }
    }
}
