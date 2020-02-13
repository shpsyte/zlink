using AutoMapper;
using Business.Interfaces;
using Business.Notifications;
using Business.Services;
using Data.Context;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Services;

namespace WebApp.Config {
    public static class InjectDependencyConfig {

        public static IServiceCollection AddInjectDependencyConfig (this IServiceCollection services) {

            services.AddAutoMapper (typeof (Startup));
            services.AddLogging ();
            services.AddSignalR ();
            services.AddScoped<AppDbContext> ();
            services.AddScoped<ITagRepository, TagRepository> ();
            services.AddScoped<ITagDataRepository, TagDataRepository> ();
            services.AddScoped<ITagServices, TagServices> ();
            services.AddScoped<ITagDataServices, TagDataServices> ();
            services.AddScoped<INotificador, Notificador> ();
            services.AddScoped<IControllerServices, ControllerServices> ();
            services.AddScoped<IUser, User> ();

            return services;
        }
    }
}