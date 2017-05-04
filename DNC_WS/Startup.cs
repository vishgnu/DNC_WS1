using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DNC_WS
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // core pipline 1
            app.Use(async (context, next) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Eins rein</br>");
                await next();
                await context.Response.WriteAsync("Eins raus</br>");
            });

            // core pipline 2
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Zwei rein</br>");
                await next();
                await context.Response.WriteAsync("Zwei  raus</br>");
            });

            // run real app
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hage Gage!</br>");
            });
        }
    }
}
