using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brive.Inventory.BusinessLogic;
using Brive.Inventory.DataAccess;
using Brive.Inventory.Framework.Common.Interfaces.Product;
using Brive.Inventory.Framework.Providers;
using Brive.Inventory.Framework.Providers.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Brive.Inventory.API
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
            services.AddControllers();
            services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();
            services.AddScoped<IProductDataAccess, ProductDataAccess>();
            services.AddScoped<IInventoryBusinessLogic, InventoryBusinessLogic>();
            services.AddScoped<IInventoryDataAccess, InventoryDataAccess>();
            services.AddScoped<IStoreBusinessLogic, StoreBusinessLogic>();
            services.AddScoped<IStoreDataAccess, StoreDataAccess>();
            services.AddScoped<IDapper, DapperManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
