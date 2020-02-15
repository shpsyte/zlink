using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Config {
    public static class DbContextConfig {
        public static IServiceCollection AddDbContextConfig (this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<AppDbContext> (options =>
                options.UseSqlServer (
                    configuration.GetConnectionString ("DefaultConnection")));

            return services;
        }

    }

}