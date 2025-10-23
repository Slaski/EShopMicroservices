namespace Catalog.API.Configurations
{
    internal static class ValidatorConfigurations
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ValidatorConfigurations).Assembly);
        }
    }
}
