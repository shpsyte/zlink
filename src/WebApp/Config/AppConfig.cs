using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebApp.Hubs;

namespace WebApp.Config {
    public static class AppConfig {
        public static IApplicationBuilder AddRoutes (this IApplicationBuilder app) {

            app.UseSignalR (routes => {
                routes.MapHub<NewTagHub> ("/newTagHub");
            });

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            return app;

        }

        public static IApplicationBuilder AddConfig (this IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            } else {
                app.UseExceptionHandler ("/erro/500");
                app.UseStatusCodePagesWithRedirects ("/erro/{0}");
                app.UseHsts ();
            }

            return app;
        }

    }

}