using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Config
{
  public static partial class MVCConfig {
        public static IServiceCollection AddMVCConfig (this IServiceCollection services) {

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            return services;
        }
    }
}