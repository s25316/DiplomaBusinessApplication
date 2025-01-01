using Microsoft.Extensions.DependencyInjection;
using Regon.Repositories.Requests;
using Regon.Services.EnvelopesForRequest;
using Regon.Services.MainService;

namespace Regon
{
    public static class Configuration
    {
        public static IServiceCollection RegonConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IRequestEnvelopes, RequestEnvelopes>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IRegonService, RegonService>();
            return services;
        }
    }
}
