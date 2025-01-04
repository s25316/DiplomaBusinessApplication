using Microsoft.Extensions.DependencyInjection;
using Radon.Repositories;
using Radon.Services;

namespace Radon
{
    public static class Configuration
    {
        public static IServiceCollection RadonConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IRadonRepository, RadonRepository>();
            services.AddTransient<IRadonService, RadonService>();
            return services;
        }
    }
}
