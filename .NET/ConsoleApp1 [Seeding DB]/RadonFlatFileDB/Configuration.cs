using Microsoft.Extensions.DependencyInjection;
using RadonFlatFileDB.Repositories;
using RadonFlatFileDB.Services;

namespace RadonFlatFileDB
{
    public static class Configuration
    {
        public static IServiceCollection RadonFilesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IRadonService, RadonService>();
            services.AddTransient<IRadonRepository, RadonRepository>();
            return services;
        }
    }
}
