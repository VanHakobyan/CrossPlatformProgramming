using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AspCoreModule2.Services;

namespace AspCoreModule2
{
    public class Startup
    {

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile(@"C:\Users\VAN\Source\Repos\CrossPlatformProgramming\AspCoreModule2\AspCoreModule2\Config.json");
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var welcome = greeter.GetGreeting();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(welcome);
            });
        }
    }
}
