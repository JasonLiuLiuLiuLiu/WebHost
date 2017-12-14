using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebHost
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration,IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Console.WriteLine("Strated");
            });
            applicationLifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine("Stoping");
            });
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                Console.WriteLine("Strated");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"name=\"{env.ApplicationName}\"");
                await context.Response.WriteAsync($"name=\"{env.ContentRootFileProvider}\"");
                await context.Response.WriteAsync($"name=\"{env.ContentRootPath}\"");
                await context.Response.WriteAsync($"name=\"{env.EnvironmentName}\"");
                await context.Response.WriteAsync($"name=\"{env.WebRootFileProvider}\"");   //不一一输出了  原理一样的
                //await context.Response.WriteAsync($"connectionString=\"{configuration["connectionString:defaultConnectionString"]}\"");
                //await context.Response.WriteAsync($"name=\"{configuration["name"]}\"");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
