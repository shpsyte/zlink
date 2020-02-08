using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Config {
    public static class MVCConfig {
        public static IServiceCollection AddMVCConfig (this IServiceCollection services) {

            services.AddMvc (o => {
                o.Filters.Add (new AutoValidateAntiforgeryTokenAttribute ());

            }).SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            return services;
        }

    }

}