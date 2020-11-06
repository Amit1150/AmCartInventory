using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Business;
using Inventory.Core.Business;
using Inventory.Core.Repositories;
using Inventory.Data;
using Inventory.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Inventory.Service
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

            services.AddDbContext<AmCartDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("HMSAppContext")));

            SetupBusiness(services);
            SetupRepositories(services);
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

        #region Setup Repositories
        private void SetupRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private void SetupBusiness(IServiceCollection services)
        {
            services.AddScoped<IProductBll, ProductBll>();
        }
        #endregion
    }
}
