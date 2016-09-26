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
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.Enities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace OnlineShoppingWeb
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(config => config.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver());
            services.AddEntityFramework()
                .AddDbContext<ProductDbContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<User, IdentityRole>()
                           .AddEntityFrameworkStores<ProductDbContext>()
                           .AddDefaultTokenProviders();
            services.AddScoped<IProductData, SqlServerLaptopData>();

            services.AddScoped<IDepartmentData, SqlDepartmentData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            Mapper.Initialize(config => { config.CreateMap<IProduct, Laptop>().ReverseMap(); });
            app.UseIdentity();

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseMvc(routes =>
            {
 
                //routes.MapRoute(
                //    name: "User",
                //    template: "{controller}/{action}/{departmentId?}/{subDepartmentId?}/{productId?}",
                //    defaults: new { controller = "Department", action = "Index"}
                //);
                routes.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index"}
                );
            });
        
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("404 Not found");
            });
        }
    }
}
