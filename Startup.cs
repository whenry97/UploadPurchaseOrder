// Startup Class for Upload Purchase Order Web Application
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UploadPurchaseOrder.Data;
using Microsoft.EntityFrameworkCore;

namespace UploadPurchaseOrder
{
    public class Startup
    {
        // Constructor 
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Use Sqlite in development environment, SQL Server in production
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PurchaseOrderContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("PurchaseOrderContext")));
            }
            else
            {
                services.AddDbContext<PurchaseOrderContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PurchaseOrderContext")));    
            }
            // Configure MVC services for Razor Pages
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
