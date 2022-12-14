using Aplicacion.Contratos;
using Aplicacion.Core;
using Aplicacion.Implementacion;
using Datos.Persistencia.Core;
using Datos.Persistencia.Implementacion;
using Dominio.Contratos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Aplicacion.Implementacion.Clases;

namespace LibraryTRAVELApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContextoPrincipal>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("ConexionTest")));

            services.AddControllers();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryTRAVELApi", Version = "v1" });
            });

            services.AddTransient<IContextoUnidaDeTrabajo, ContextoPrincipal>();

            services.AddTransient<IAutoresRepositorio, autoresRepositorio>();
            services.AddTransient<IAutoresServicio, autoresServicio>();
            services.AddTransient<IEditorialesRepositorio, editorialesRepositorio>();
            services.AddTransient<IEditorialesServicio, editorialesServicio>();
            services.AddTransient<ILibrosRepositorio, librosRepositorio>();
            services.AddTransient<ILibrosServicio, librosServicio>();

            services.AddTransient<IAutoresHasLibrosRepositorio, autoresHasLibrosRepositorio>();

            /*
            services.AddCors(options => 
            {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4201")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowAnyOrigin();
                    });
            });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryTRAVELApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors("MyPolicy");
            app.UseCors(per => per.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            
            
        }
    }
}
