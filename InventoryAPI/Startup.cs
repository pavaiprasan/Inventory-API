using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using InventoryAPI.Service;
using InventoryAPI.Services.Interface;
using InventoryAPI.Models;
using InventoryAPI.Entity;


namespace InventoryAPI
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
            services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.WithMethods("GET","OPTIONS","PUT")
					.AllowCredentials();
				});
			});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Inventory API",
                    Description = "Inventory API"
                });
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<ISalesService, SalesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseRouting();

            app.UseAuthentication();
            app.UseDefaultFiles();
			app.UseStaticFiles();            
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API V1");
            });
            app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
        }
    }
}
