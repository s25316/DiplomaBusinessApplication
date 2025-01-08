using Application.DatabaseRelational;
using Infrastructure.DatabaseRelational;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection InfrastructureConfiguration(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddTransient<MyPlatformDbContext, MyPlatformMsSqlDbContext>();
            return serviceCollection;
        }
    }
}
