using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using demobackend.Data;
using demobackend.Models;
using demobackend.Services;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.Cookies;
using demobackend.AutoMapperProfile;

namespace demobackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
   
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
               builder.WithOrigins("http://localhost:4200");
               builder.AllowCredentials();
               builder
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
             
            services.ConfigureApplicationCookie(options => 
            {
                 options.ExpireTimeSpan = new TimeSpan(1,1,1);
            });
           // Add application services.
            services.AddMvc();

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                });
           
            var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutoMapperProfileConfiguration());
                });
              
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseCors("MyPolicy");  
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseIdentity();
            app.UseMvc();     
        }
    }
}
