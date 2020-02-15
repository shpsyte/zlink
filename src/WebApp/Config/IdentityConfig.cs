using Business.Models;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Config {
    public static partial class IdentityConfig {
        public static IServiceCollection AddIdentityConfig (this IServiceCollection services, IConfiguration configuration) {

            services.Configure<CookiePolicyOptions> (options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext> (options =>
                options.UseSqlServer (
                    configuration.GetConnectionString ("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser> (a => {
                    a.User.RequireUniqueEmail = true;
                })
                .AddDefaultUI (UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AppDbContext> ();

            return services;
        }
    }
}