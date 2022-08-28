// Se agregan configuraciones adicionales como inyecciones de dependencias, servicios
// que utilizara la api

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


using WebApiCRUD.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        // damos de alta el servicio de la cadena de conexon para utilizar DbContext en el repository
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x=>{
                x.UseLazyLoadingProxies();
                x.UseMySql(Configuration.GetConnectionString("Defaultconnection"));
            });
            services.AddControllers();
            services.AddScoped<IApiRepository,ApiRepository>(); // Cuando queramos utilizar nuestro repositorio ( En los controllers ) es necesario poder inyectarlo para que sea utilizado.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
