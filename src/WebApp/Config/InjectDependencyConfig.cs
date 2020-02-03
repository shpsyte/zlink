using AutoMapper;
using Business.Interfaces;
using Data.Context;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Config
{
  public static class InjectDependencyConfig {

        public static IServiceCollection AddInjectDependencyConfig (this IServiceCollection services) {

            services.AddAutoMapper (typeof (Startup));
            services.AddScoped<AppDbContext> ();
            services.AddScoped<ITagRepository, TagRepository> ();
            services.AddScoped<ITagDataRepository, TagDataRepository> ();

            return services;
        }
    }
}