using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Config;

namespace WebApp {
    public class Startup {
        public IConfiguration Configuration { get; }
        public Startup (IHostingEnvironment host) {

            var builder = new ConfigurationBuilder ()
                .SetBasePath (host.ContentRootPath)
                .AddJsonFile ("appsettings.json", true, true)
                .AddJsonFile ($"appsettings.{host.EnvironmentName}.json", true, true);

            Configuration = builder.Build ();

        }

        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContextConfig (Configuration);
            services.AddIdentityConfig (Configuration);
            services.AddIpServices (Configuration);
            services.AddInjectDependencyConfig ();
            services.AddMVCConfig ();
             

        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.AddConfig (env);
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();
            app.UseAuthentication ();
            app.AddRoutes ();

        }
    }
}