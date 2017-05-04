using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace DNC_WS
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {

            // adding json config file
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add serices here -- auth - id ,,,,
            services.AddOptions();
            services.AddReinRaus(options => {
                options.Nummer = Configuration["ReinRaus:Nummer"];
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // core pipline 1 extern mdw
            app.UseMiddleware<ReinRausMiddleware>();

            //core pipline 2
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Zwei rein</br>");
            //    await next();
            //    await context.Response.WriteAsync("Zwei  raus</br>");
            //});

            // run real app
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hage Gage!</br>");
            });
        }
    }
}
