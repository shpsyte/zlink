using Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Config {
    public static class IPServicesConfig {
        public static IServiceCollection AddIpServices (this IServiceCollection services, IConfiguration configuration) {

            services.Configure<IPProviderAPI> (configuration);
            services.AddScoped<IIpServices, IpServices> ();

            return services;
        }

    }

}