using System.Linq;
using System;
using AlfredoRevillaWebshop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AlfredoRevillaWebshop.Repositories.Implementations;
using AlfredoRevillaWebshop.Repositories;
using AlfredoRevillaWebshop.Repositories.Extensions;
using Microsoft.AspNetCore.Http;
using AlfredoRevillaWebshop.Repositories.Implementations.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace AlfredoRevillaWebshop
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IProductsRepositoryFactory>((o) => new DefaultProductsRepositoryFactory(Configuration));

            services.AddScoped<ProductService>();
            services.AddScoped<IProductsRepository>((o) => o.GetRequiredService<IProductsRepositoryFactory>().Create(o.GetRequiredService<IHttpContextAccessor>().HttpContext.GetRequestedRepository()));
        }
    }
}